using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    public interface ITypeBuildingContext
    {
        bool IsDefinitionBuilded { get; }
        void Initialize(ITypeGenerator typeGenerator);
        void BuildDefinition(ITypeGenerator typeGenerator);
        TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator);
    }
}