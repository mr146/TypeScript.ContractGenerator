namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptTypePropertyGetterDeclaration : TypeScriptTypeMemberDeclarationBase
    {
        public TypeScriptArgumentDeclaration Argument { get; set; }
        public TypeScriptType ResultType { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            if(context.TypeChecker == JavaScriptTypeChecker.TypeScript)
            {
                var argument = Argument.GenerateCode(context);
                if(argument != "string" || argument != "number")
                {
                    return $"[key: string]: {ResultType.GenerateCode(context)};";
                }
            }

            return $"[{Argument.GenerateCode(context)}]: {ResultType.GenerateCode(context)};";
        }
    }
}