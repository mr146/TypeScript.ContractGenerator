using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Http;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Extensions;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Infection;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    public class CustomTypeTypeBuildingContextImpl : TypeBuildingContext
    {
        public CustomTypeTypeBuildingContextImpl(TypeScriptUnit unit, Type type)
            : base(unit, type)
        {
        }

        public override bool IsDefinitionBuilded { get { return Declaration.Definition != null; } }

        public override void Initialize(ITypeGenerator typeGenerator)
        {
            if(Type.BaseType != typeof(object)
            && Type.BaseType != typeof(ValueType)
            && Type.BaseType != typeof(MarshalByRefObject)
            && Type.BaseType != null
            && !typeof(ApiController).IsAssignableFrom(Type)
            && !Type.BaseType.IsAbstract
            )
            {
                typeGenerator.ResolveType(Type.BaseType);
            }

            Type type = Type;
            var result = new TypeScriptTypeDeclaration
                {
                    Name = type.IsGenericType ? new Regex("`.*$").Replace(type.GetGenericTypeDefinition().Name, "") : type.Name,
                    Definition = null,
                };
            Declaration = result;
            Unit.Body.Add(new TypeScriptExportTypeStatement {Declaration = Declaration});
        }

        public override void BuildDefinition(ITypeGenerator typeGenerator)
        {
            Declaration.Definition = CreateComplexTypeScriptDefinition(typeGenerator);
        }

        protected virtual TypeScriptTypeDefintion CreateComplexTypeScriptDefinition(ITypeGenerator typeGenerator)
        {
            var result = new TypeScriptTypeDefintion();
            var properties = CreateTypeProperties(Type);
            foreach(var property in properties)
            {
                var constValueByClassTypeAttribute = Attribute.GetCustomAttributes(property).Any(x => x.GetType().Name == "ConstValueByClassTypeAttribute");
                var valueIsAlwaysAttribute = Attribute.GetCustomAttributes(property).FirstOrDefault(x => x.GetType().Name == "ValueIsAlwaysAttribute");
                if(constValueByClassTypeAttribute)
                {
                    result.Members.Add(new TypeScriptTypeMemberDeclaration
                        {
                            Name = BuildPropertyName(property.Name),
                            Type = new TypeScriptStringLiteral(Type.Name)
                        });
                }
                else if(valueIsAlwaysAttribute != null)
                {
                    var value = ((ValueIsAlwaysAttribute)valueIsAlwaysAttribute).EnumValue;
                    result.Members.Add(new TypeScriptTypeMemberDeclaration
                        {
                            Name = BuildPropertyName(property.Name),
                            Type = new TypeScriptEnumValue(typeGenerator.BuildAndImportType(Unit, property, property.PropertyType), value),
                        });
                }
                else
                {
                    result.Members.Add(new TypeScriptTypeMemberDeclaration
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