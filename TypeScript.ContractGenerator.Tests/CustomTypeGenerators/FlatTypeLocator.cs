using System;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators
{
    public class FlatTypeLocator : ICustomTypeGenerator
    {
        public string GetTypeLocation(Type type)
        {
            return type.Name;
        }
        
        public ITypeBuildingContext ResolveType(string initialUnitPath, Type type, ITypeScriptUnitFactory unitFactory)
        {
            return null;
        }
    }
}