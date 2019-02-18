using System;
using System.Linq;

using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    public class BuildInTypeBuildingContext : ITypeBuildingContext
    {
        public BuildInTypeBuildingContext(Type type)
        {
            this.type = type;
        }

        public static bool Accept(Type type)
        {
            return buildInTyped.Contains(type);
        }

        public TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator)
        {
            if(type == typeof(string))
                return new TypeScriptBuildInType("string");
            else if(type == typeof(bool))
                return new TypeScriptBuildInType("boolean");
            else if(type == typeof(int))
                return new TypeScriptBuildInType("number");
            else if(type == typeof(decimal))
                return new TypeScriptBuildInType("number");
            else if(type == typeof(Int64))
                return new TypeScriptBuildInType("string");
            else if(type == typeof(byte[]))
                return new TypeScriptBuildInType("string");
            else if(type == typeof(void))
                return new TypeScriptBuildInType("void");
            throw new ArgumentOutOfRangeException();
        }

        public bool IsDefinitionBuilded { get { return true; } }

        public void Initialize(ITypeGenerator typeGenerator)
        {
        }

        public void BuildDefinition(ITypeGenerator typeGenerator)
        {
        }

        private readonly Type type;

        private static readonly Type[] buildInTyped =
            {
                typeof(string),
                typeof(bool),
                typeof(int),
                typeof(decimal),
                typeof(Int64),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(void),
                typeof(byte[]),
            };
    }
}