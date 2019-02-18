namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public abstract class TypeScriptType
    {
        public abstract string GenerateCode(ICodeGenerationContext context);
    }
}