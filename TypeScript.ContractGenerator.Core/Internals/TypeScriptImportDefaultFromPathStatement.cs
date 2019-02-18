using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals
{
    internal class TypeScriptImportDefaultFromPathStatement : TypeScriptImportStatement
    {
        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("import {0} from '{1}';", TypeName, context.GetReferenceFromUnitToAnother(CurrentUnit.Path, PathToUnit));
        }

        public string TypeName { get; set; }
        public TypeScriptUnit CurrentUnit { get; set; }
        public string PathToUnit { get; set; }
    }
}