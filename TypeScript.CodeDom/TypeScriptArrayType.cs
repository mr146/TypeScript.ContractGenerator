namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptArrayType : TypeScriptType
    {
        public TypeScriptArrayType(TypeScriptType itemType)
        {
            ItemType = itemType;
        }

        public TypeScriptType ItemType { get; private set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return ItemType.GenerateCode(context) + "[]";
        }
    }
}