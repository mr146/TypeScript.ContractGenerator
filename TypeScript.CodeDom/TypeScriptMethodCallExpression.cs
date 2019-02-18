using System.Collections.Generic;
using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptMethodCallExpression : TypeScriptExpression
    {
        public TypeScriptMethodCallExpression(TypeScriptExpression subject, string methodName, params TypeScriptType[] arguments)
        {
            Subject = subject;
            MethodName = methodName;
            Arguments.AddRange(arguments.Where(x => x != null));
        }

        public TypeScriptExpression Subject { get; set; }
        public string MethodName { get; set; }
        public List<TypeScriptType> Arguments { get; } = new List<TypeScriptType>();

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("{0}.{1}({2})", Subject.GenerateCode(context), MethodName, string.Join(", ", Arguments.Select(x => x.GenerateCode(context))));
        }
    }
}