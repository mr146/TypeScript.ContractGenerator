using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators
{
    public class DictionaryTypeBuildingContext : ITypeBuildingContext
    {
        public DictionaryTypeBuildingContext(Type dictionaryType)
        {
            keyType = dictionaryType.GetGenericArguments()[0];
            valueType = dictionaryType.GetGenericArguments()[1];
        }

        public bool IsDefinitionBuilded => true;

        public void Initialize(ITypeGenerator typeGenerator)
        {
        }

        public void BuildDefinition(ITypeGenerator typeGenerator)
        {
        }

        public TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator)
        {
            var keyFlowType = typeGenerator.ResolveType(keyType).ReferenceFrom(targetUnit, typeGenerator);
            var valueFlowType = typeGenerator.ResolveType(valueType).ReferenceFrom(targetUnit, typeGenerator);

            return new TypeScriptTypeDefintion
                {
                    Members =
                        {
                            new TypeScriptTypePropertyGetterDeclaration
                                {
                                    Argument = new TypeScriptArgumentDeclaration
                                        {
                                            Name = "key",
                                            Type = keyFlowType,
                                        },
                                    ResultType = valueFlowType,
                                }
                        }
                };
        }

        private readonly Type keyType;
        private readonly Type valueType;
    }
}