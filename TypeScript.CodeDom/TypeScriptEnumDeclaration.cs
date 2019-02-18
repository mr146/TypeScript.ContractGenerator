using System.Text;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptEnumDeclaration : TypeScriptTypeDeclaration
    {
        public override string GenerateCode(ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.AppendFormat("enum {0} ", Name);
            result.Append(Definition.GenerateCode(context));
            return result.ToString();
        }
    }
}