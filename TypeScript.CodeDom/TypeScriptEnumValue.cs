namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptEnumValue : TypeScriptType
    {
        public TypeScriptEnumValue(TypeScriptType enumType, string value)
        {
            this.enumType = enumType;
            this.value = value;
        }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return $"{enumType.GenerateCode(context)}.{value}";
        }

        private readonly TypeScriptType enumType;
        private readonly string value;
    }
}