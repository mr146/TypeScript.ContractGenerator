using System;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    public class TypeBuildingContext : ITypeBuildingContext
    {
        protected TypeBuildingContext([NotNull] FlowTypeUnit unit, [NotNull] Type type)
        {
            Unit = unit;
            Type = type;
        }

        public virtual void Initialize([NotNull] ITypeGenerator typeGenerator)
        {
            Unit.Body.Add(new FlowTypeExportTypeStatement {Declaration = Declaration});
        }

        protected FlowTypeTypeDeclaration Declaration { get; set; }

        [NotNull]
        protected FlowTypeUnit Unit { get; }

        [NotNull]
        protected Type Type { get; }

        public virtual bool IsDefinitionBuilt => true;

        public virtual void BuildDefinition([NotNull] ITypeGenerator typeGenerator)
        {
        }

        public virtual FlowTypeType ReferenceFrom(FlowTypeUnit targetUnit, [NotNull] ITypeGenerator typeGenerator)
        {
            return targetUnit.AddTypeImport(Type, Declaration, Unit);
        }
    }
}