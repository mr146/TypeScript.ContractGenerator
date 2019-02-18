using System;
using System.Reflection;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core
{
    public interface ITypeGenerator
    {
        ITypeBuildingContext ResolveType(Type type);
        TypeScriptType BuildAndImportType(TypeScriptUnit targetUnit, ICustomAttributeProvider attributeProvider, Type type, bool notNull = false);
    }
}