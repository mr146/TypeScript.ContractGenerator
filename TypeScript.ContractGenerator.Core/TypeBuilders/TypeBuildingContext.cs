using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    public class TypeBuildingContext : ITypeBuildingContext
    {
        public TypeBuildingContext(TypeScriptUnit unit, Type type)
        {
            Unit = unit;
            Type = type;
        }

        public virtual void Initialize(ITypeGenerator typeGenerator)
        {
            Unit.Body.Add(new TypeScriptExportTypeStatement {Declaration = Declaration});
        }

        public TypeScriptTypeDeclaration Declaration { get; set; }
        public TypeScriptUnit Unit { get; set; }
        public Type Type { get; set; }
        public virtual bool IsDefinitionBuilded { get { return true; } }

        public virtual void BuildDefinition(ITypeGenerator typeGenerator)
        {
        }

        public virtual TypeScriptType ReferenceFrom(TypeScriptUnit targetUnit, ITypeGenerator typeGenerator)
        {
            return targetUnit.AddTypeImport(Type, Declaration, Unit);
        }
    }
}