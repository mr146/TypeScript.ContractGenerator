using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptConstructorCall : TypeScriptExpression
    {
        public string ClassName { get; set; }
        public TypeScriptExpression[] Arguments { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return $"new {ClassName}({string.Join(", ", (Arguments ?? new TypeScriptExpression[0]).Select(x => x.GenerateCode(context)))})";
        }
    }
}