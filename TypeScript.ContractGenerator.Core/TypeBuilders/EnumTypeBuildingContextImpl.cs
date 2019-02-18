using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders
{
    internal class EnumTypeBuildingContextImpl : TypeBuildingContext
    {
        public EnumTypeBuildingContextImpl(TypeScriptUnit unit, Type type)
            : base(unit, type)
        {
        }

        public override void Initialize(ITypeGenerator typeGenerator)
        {
            var values = Type.GetEnumNames();
            var enumResult = new TypeScriptEnumDeclaration
                {
                    Name = Type.Name,
                    Definition = new TypeScriptEnumDefinition(Type),
                };
            Unit.Body.Add(
                new TypeScriptExportTypeStatement
                    {
                        Declaration = enumResult
                    });
            Declaration = enumResult;
        }
    }
}