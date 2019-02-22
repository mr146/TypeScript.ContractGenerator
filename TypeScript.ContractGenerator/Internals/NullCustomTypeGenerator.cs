using System;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    internal class NullCustomTypeGenerator : ICustomTypeGenerator
    {
        [NotNull]
        public string GetTypeLocation([NotNull] Type type)
        {
            return "";
        }

        [CanBeNull]
        public ITypeBuildingContext ResolveType([NotNull] string initialUnitPath, [NotNull] Type type, [NotNull] IFlowTypeUnitFactory unitFactory)
        {
            return null;
        }
    }
}