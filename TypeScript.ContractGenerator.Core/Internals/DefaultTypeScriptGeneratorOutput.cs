using System.Collections.Generic;
using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals
{
    internal class DefaultTypeScriptGeneratorOutput : ITypeScriptUnitFactory
    {
        public TypeScriptUnit[] Units { get { return units.Values.ToArray(); } }

        public TypeScriptUnit GetOrCreateTypeUnit(string path)
        {
            TypeScriptUnit result;
            if(units.TryGetValue(path, out result))
                return result;
            result = new TypeScriptUnit
                {
                    Path = path,
                };
            units.Add(path, result);
            return result;
        }

        private readonly Dictionary<string, TypeScriptUnit> units = new Dictionary<string, TypeScriptUnit>();
    }
}