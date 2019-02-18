using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    public class ArrayTypeBuildingContext : ITypeBuildingContext
    {
        public ArrayTypeBuildingContext(Type elementType)
        {
            this.elementType = elementType;
        }

        public bool IsDefinitionBuilded { get { return true; } }

        public void Initialize(ITypeGenerator typeGenerator)
        {
        }

        public void BuildDefinition(ITypeGenerator typeGenerator)
        {
        }

        public TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator)
        {
            var itemType = typeGenerator.ResolveType(elementType).ReferenceFrom(targetUnit, typeGenerator);
            return new TypeScriptArrayType(itemType);
        }

        private readonly Type elementType;
    }
}