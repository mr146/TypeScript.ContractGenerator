using System;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core
{
    public interface ICustomTypeGenerator
    {
        string GetTypeLocation(Type type);
        ITypeBuildingContext ResolveType(string initialUnitPath, Type type, ITypeScriptUnitFactory unitFactory);
    }
}