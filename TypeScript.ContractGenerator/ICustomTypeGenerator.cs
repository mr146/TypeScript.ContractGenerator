using System;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public interface ICustomTypeGenerator
    {
        [NotNull]
        string GetTypeLocation([NotNull] Type type);

        [CanBeNull]
        ITypeBuildingContext ResolveType([NotNull] string initialUnitPath, [NotNull] Type type, [NotNull] IFlowTypeUnitFactory unitFactory);
    }
}