using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    public class BuildInTypeBuildingContext : ITypeBuildingContext
    {
        public BuildInTypeBuildingContext([NotNull] Type type)
        {
            this.type = type;
        }

        public static bool Accept([NotNull] Type type)
        {
            return builtinTypes.ContainsKey(type);
        }

        [NotNull]
        public FlowTypeType ReferenceFrom(FlowTypeUnit targetUnit, [NotNull] ITypeGenerator typeGenerator)
        {
            if (builtinTypes.ContainsKey(type))
                return new FlowTypeBuildInType(builtinTypes[type]);
            throw new ArgumentOutOfRangeException();
        }

        public bool IsDefinitionBuilt => true;

        public void Initialize([NotNull] ITypeGenerator typeGenerator)
        {
        }

        public void BuildDefinition([NotNull] ITypeGenerator typeGenerator)
        {
        }

        private readonly Type type;

        private static readonly Dictionary<Type, string> builtinTypes = new Dictionary<Type, string>
            {
                {typeof(bool), "boolean"},
                {typeof(int), "number"},
                {typeof(uint), "number"},
                {typeof(short), "number"},
                {typeof(ushort), "number"},
                {typeof(byte), "number"},
                {typeof(sbyte), "number"},
                {typeof(float), "number"},
                {typeof(double), "number"},
                {typeof(decimal), "number"},
                {typeof(DateTime), "(Date | string)"},
                {typeof(TimeSpan), "(number | string)"},
                {typeof(string), "string"},
                {typeof(long), "string"},
                {typeof(ulong), "string"},
                {typeof(byte[]), "string"},
                {typeof(Guid), "string"},
                {typeof(char), "string"},
                {typeof(void), "void"}
            };
    }
}