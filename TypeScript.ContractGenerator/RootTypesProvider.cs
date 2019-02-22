using System;

using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public class RootTypesProvider : IRootTypesProvider
    {
        public RootTypesProvider(params Type[] rootTypes)
        {
            this.rootTypes = rootTypes ?? new Type[0];
        }

        [NotNull, ItemNotNull]
        public Type[] GetRootTypes()
        {
            return rootTypes;
        }

        [NotNull]
        public static IRootTypesProvider Default { get; } = new RootTypesProvider();

        private readonly Type[] rootTypes;
    }
}