using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    public interface ITypeBuildingContext
    {
        bool IsDefinitionBuilt { get; }
        void Initialize([NotNull] ITypeGenerator typeGenerator);
        void BuildDefinition([NotNull] ITypeGenerator typeGenerator);
        FlowTypeType ReferenceFrom(FlowTypeUnit targetUnit, [NotNull] ITypeGenerator typeGenerator);
    }
}