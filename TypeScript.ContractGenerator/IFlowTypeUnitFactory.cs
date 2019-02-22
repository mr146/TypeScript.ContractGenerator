using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public interface IFlowTypeUnitFactory
    {
        [NotNull]
        FlowTypeUnit GetOrCreateTypeUnit([NotNull] string path);
    }
}