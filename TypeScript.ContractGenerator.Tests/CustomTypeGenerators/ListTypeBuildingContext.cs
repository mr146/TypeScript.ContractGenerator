using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators
{
    public class ListTypeBuildingContext : ITypeBuildingContext
    {
        public ListTypeBuildingContext(Type listType)
        {
            itemType = listType.GetGenericArguments()[0];
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
            var itemFlowType = typeGenerator.ResolveType(itemType).ReferenceFrom(targetUnit, typeGenerator);
            return new TypeScriptArrayType(itemFlowType);
        }

        private readonly Type itemType;
    }
}