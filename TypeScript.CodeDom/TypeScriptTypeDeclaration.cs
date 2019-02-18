namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptTypeDeclaration : TypeScriptStatement
    {
        public string Name { get; set; }
        public TypeScriptType Definition { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("type {0} = {1};", Name, Definition.GenerateCode(context));
        }
    }
}