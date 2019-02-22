using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;
using SkbKontur.TypeScript.ContractGenerator.Extensions;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class CustomTypeTypeBuildingContext : TypeBuildingContext
    {
        public CustomTypeTypeBuildingContext([NotNull] FlowTypeUnit unit, [NotNull] Type type, [NotNull] FlowTypeGenerationOptions options)
            : base(unit, type)
        {
            this.options = options;
        }

        public override bool IsDefinitionBuilt => Declaration.Definition != null;

        [NotNull]
        private FlowTypeTypeDeclaration CreateComplexFlowTypeDeclarationWithoutDefinition([NotNull] Type type)
        {
            var result = new FlowTypeTypeDeclaration
                {
                    Name = type.IsGenericType ? new Regex("`.*$").Replace(type.GetGenericTypeDefinition().Name, "") : type.Name,
                    Definition = null,
                    GenericTypeArguments = Type.IsGenericTypeDefinition ? Type.GetGenericArguments().Select(x => x.Name).ToArray() : null
                };
            return result;
        }

        public override void Initialize([NotNull] ITypeGenerator typeGenerator)
        {
            if (Type.BaseType != typeof(object) && Type.BaseType != typeof(ValueType) && Type.BaseType != typeof(MarshalByRefObject) && Type.BaseType != null)
            {
                typeGenerator.ResolveType(Type.BaseType);
            }
            Declaration = CreateComplexFlowTypeDeclarationWithoutDefinition(Type);
            Unit.Body.Add(new FlowTypeExportTypeStatement {Declaration = Declaration});
        }

        public override void BuildDefinition([NotNull] ITypeGenerator typeGenerator)
        {
            Declaration.Definition = CreateComplexFlowTypeDefinition(typeGenerator);
        }

        [NotNull]
        protected virtual FlowTypeTypeDefintion CreateComplexFlowTypeDefinition([NotNull] ITypeGenerator typeGenerator)
        {
            var result = new FlowTypeTypeDefintion();
            var properties = CreateTypeProperties(Type);
            foreach (var property in properties)
            {
                var (isNullable, type) = FlowTypeGeneratorHelpers.ProcessNullable(property, property.PropertyType);

                result.Members.Add(new FlowTypeTypeMemberDeclaration
                    {
                        Name = BuildPropertyName(property.Name),
                        Optional = isNullable && options.EnableOptionalProperties,
                        Type = GetMaybeNullableComplexType(typeGenerator, type, property, isNullable),
                    });
            }
            return result;
        }

        private FlowTypeType GetMaybeNullableComplexType([NotNull] ITypeGenerator typeGenerator, [NotNull] Type type, [NotNull] PropertyInfo property, bool isNullable)
        {
            var propertyType = typeGenerator.BuildAndImportType(Unit, null, type);

            if (property.PropertyType.IsGenericParameter)
                return new FlowTypeTypeReference(property.PropertyType.Name);

            if (isNullable && options.EnableExplicitNullability && !options.UseGlobalNullable)
                return new FlowTypeOrNullType(propertyType);

            if (isNullable && options.EnableExplicitNullability && options.UseGlobalNullable)
                return new FlowTypeNullableType(propertyType);

            return propertyType;
        }

        private static string BuildPropertyName(string propertyName)
        {
            return propertyName.ToLowerCamelCase();
        }

        [NotNull, ItemNotNull]
        protected virtual PropertyInfo[] CreateTypeProperties([NotNull] Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        private readonly FlowTypeGenerationOptions options;
    }
}