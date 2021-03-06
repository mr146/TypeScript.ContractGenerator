namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class TypeScriptTypeDeclaration : TypeScriptStatement
    {
        public string Name { get; set; }
        public TypeScriptType Definition { get; set; }
        public string[] GenericTypeArguments { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            if (GenericTypeArguments != null && GenericTypeArguments.Length > 0)
            {
                return string.Format("type {0}<{1}> = {2};", Name, string.Join(", ", GenericTypeArguments), Definition.GenerateCode(context));
            }
            return string.Format("type {0} = {1};", Name, Definition.GenerateCode(context));
        }
    }
}