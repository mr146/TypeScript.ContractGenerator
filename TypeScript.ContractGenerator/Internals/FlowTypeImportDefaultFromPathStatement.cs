using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    internal class FlowTypeImportDefaultFromPathStatement : FlowTypeImportStatement
    {
        public override string GenerateCode([NotNull] ICodeGenerationContext context)
        {
            return string.Format("import {0} from '{1}';", TypeName, context.GetReferenceFromUnitToAnother(CurrentUnit.Path, PathToUnit));
        }

        public string TypeName { get; set; }
        public FlowTypeUnit CurrentUnit { get; set; }
        public string PathToUnit { get; set; }
    }
}