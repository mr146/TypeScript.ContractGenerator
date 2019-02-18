using System;
using System.Collections.Generic;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators
{
    public class TestCustomTypeGenerator : ICustomTypeGenerator
    {
        public string GetTypeLocation(Type type)
        {
            return "";
        }

        public ITypeBuildingContext ResolveType(string initialUnitPath, Type type, ITypeScriptUnitFactory unitFactory)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return new ListTypeBuildingContext(type);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                return new DictionaryTypeBuildingContext(type);
            if (type == typeof(Guid))
                return new StringBuildingContext();

            return null;
        }
    }
}