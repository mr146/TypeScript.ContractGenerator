namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptPropertyMember
    {
        public string Name { get; set; }
        public TypeScriptType Result { get; set; }

        public string GenerateCode(ICodeGenerationContext context)
        {
            return $"{Name}: {Result.GenerateCode(context)}";
        }
    }
}