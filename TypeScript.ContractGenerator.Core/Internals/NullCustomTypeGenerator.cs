using System;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals
{
    internal class NullCustomTypeGenerator : ICustomTypeGenerator
    {
        public string GetTypeLocation(Type type)
        {
            return "";
        }

        public ITypeBuildingContext ResolveType(string initialUnitPath, Type type, ITypeScriptUnitFactory unitFactory)
        {
            return null;
        }
    }
}