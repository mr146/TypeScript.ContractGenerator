using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals
{
    internal class TypeScriptImportFromUnitStatement : TypeScriptImportStatement
    {
        public override string GenerateCode(ICodeGenerationContext context)
        {
            if(context.TypeChecker == JavaScriptTypeChecker.TypeScript)
            {
                return $"import {{ {TypeName} }} from '{context.GetReferenceFromUnitToAnother(CurrentUnit.Path, TargetUnit.Path)}';";
            }

            return $"import type {{ {TypeName} }} from '{context.GetReferenceFromUnitToAnother(CurrentUnit.Path, TargetUnit.Path)}';";
        }

        public string TypeName { get; set; }
        public TypeScriptUnit TargetUnit { get; set; }
        public TypeScriptUnit CurrentUnit { get; set; }
    }
}