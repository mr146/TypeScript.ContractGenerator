using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;
using SkbKontur.TypeScript.ContractGenerator.Extensions;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    public class CustomTypeTypeBuildingContextImpl : TypeBuildingContext
    {
        public CustomTypeTypeBuildingContextImpl(FlowTypeUnit unit, Type type)
            : base(unit, type)
        {
        }

        public override bool IsDefinitionBuilded { get { return Declaration.Definition != null; } }

        public override void Initialize(ITypeGenerator typeGenerator)
        {
            if(Type.BaseType != typeof(object) && Type.BaseType != typeof(ValueType) && Type.BaseType != typeof(MarshalByRefObject) && Type.BaseType != null)
            {
                typeGenerator.ResolveType(Type.BaseType);
            }
            Type type = Type;
            var result = new FlowTypeTypeDeclaration
                {
                    Name = type.IsGenericType ? new Regex("`.*$").Replace(type.GetGenericTypeDefinition().Name, "") : type.Name,
                    Definition = null,
                };
            Declaration = result;
            Unit.Body.Add(new FlowTypeExportTypeStatement {Declaration = Declaration});
        }

        public override void BuildDefinition(ITypeGenerator typeGenerator)
        {
            Declaration.Definition = CreateComplexFlowTypeDefinition(typeGenerator);
        }

        protected virtual FlowTypeTypeDefintion CreateComplexFlowTypeDefinition(ITypeGenerator typeGenerator)
        {
            var result = new FlowTypeTypeDefintion();
            var properties = CreateTypeProperties(Type);
            foreach(var property in properties)
            {
                var constValueByClassTypeAttribute = Attribute.GetCustomAttributes(property).Any(x => x.GetType().Name == "ConstValueByClassTypeAttribute");
                if(constValueByClassTypeAttribute)
                {
                    result.Members.Add(new FlowTypeTypeMemberDeclaration
                        {
                            Name = BuildPropertyName(property.Name),
                            Type = new FlowTypeStringLiteral(Type.Name)
                        });
                }
                else
                {
                    result.Members.Add(new FlowTypeTypeMemberDeclaration
                        {
                            Name = BuildPropertyName(property.Name),
                            Type = typeGenerator.BuildAndImportType(Unit, property, property.PropertyType),
                        });
                }
            }

            return result;
        }

        private string BuildPropertyName(string propertyName)
        {
            return propertyName.ToLowerCamelCase();
        }

        protected virtual PropertyInfo[] CreateTypeProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }
    }
}