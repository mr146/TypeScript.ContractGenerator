using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators
{
    public class StringBuildingContext : ITypeBuildingContext
    {
        public bool IsDefinitionBuilded => true;

        public void Initialize(ITypeGenerator typeGenerator)
        {
        }

        public void BuildDefinition(ITypeGenerator typeGenerator)
        {
        }

        public TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator)
        {
            return new TypeScriptBuildInType("string");
        }
    }
}