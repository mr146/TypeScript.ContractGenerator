namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptTypeMemberDeclaration : TypeScriptTypeMemberDeclarationBase
    {
        public string Name { get; set; }
        public TypeScriptType Type { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return Name + ": " + Type.GenerateCode(context) + ";";
        }
    }
}