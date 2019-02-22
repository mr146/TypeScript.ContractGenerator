using System;
using System.Reflection;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;
using SkbKontur.TypeScript.ContractGenerator.TypeBuilders;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public interface ITypeGenerator
    {
        [NotNull]
        ITypeBuildingContext ResolveType([NotNull] Type type);

        [NotNull]
        FlowTypeType BuildAndImportType([NotNull] FlowTypeUnit targetUnit, [CanBeNull] ICustomAttributeProvider attributeProvider, [NotNull] Type type);
    }
}