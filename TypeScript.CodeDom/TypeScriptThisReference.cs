namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptThisReference : TypeScriptExpression
    {
        public override string GenerateCode(ICodeGenerationContext context)
        {
            return "this";
        }
    }
}