using System;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.TypeBuilders
{
    internal class EnumTypeBuildingContextImpl : TypeBuildingContext
    {
        public EnumTypeBuildingContextImpl(FlowTypeUnit unit, Type type)
            : base(unit, type)
        {
        }

        public override void Initialize(ITypeGenerator typeGenerator)
        {
            var values = Type.GetEnumNames();
            var enumResult = new FlowTypeEnumDeclaration
                {
                    Name = Type.Name,
                    Definition = new FlowTypeEnumDefinition(Type),
                };
            Unit.Body.Add(
                new FlowTypeExportTypeStatement
                    {
                        Declaration = enumResult
                    });
            Declaration = enumResult;
        }
    }
}