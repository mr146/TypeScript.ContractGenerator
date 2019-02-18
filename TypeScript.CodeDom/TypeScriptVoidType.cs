namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptVoidType : TypeScriptType
    {
        public override string GenerateCode(ICodeGenerationContext context)
        {
            return "void";
        }
    }
}