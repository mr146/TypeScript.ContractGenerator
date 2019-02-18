namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptArgumentDeclaration
    {
        public string Name { get; set; }
        public TypeScriptType Type { get; set; }

        public string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("{0}: {1}", Name, Type.GenerateCode(context));
        }
    }
}