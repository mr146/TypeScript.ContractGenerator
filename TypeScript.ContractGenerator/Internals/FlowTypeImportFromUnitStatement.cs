using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    internal class FlowTypeImportFromUnitStatement : FlowTypeImportStatement
    {
        [NotNull]
        public override string GenerateCode([NotNull] ICodeGenerationContext context)
        {
            if (context.TypeChecker == JavaScriptTypeChecker.TypeScript)
            {
                return $"import {{ {TypeName} }} from '{context.GetReferenceFromUnitToAnother(CurrentUnit.Path, TargetUnit.Path)}';";
            }
            return $"import type {{ {TypeName} }} from '{context.GetReferenceFromUnitToAnother(CurrentUnit.Path, TargetUnit.Path)}';";
        }

        public string TypeName { get; set; }
        public FlowTypeUnit TargetUnit { get; set; }
        public FlowTypeUnit CurrentUnit { get; set; }
    }
}