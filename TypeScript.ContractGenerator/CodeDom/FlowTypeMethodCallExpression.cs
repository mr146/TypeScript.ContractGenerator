using System.Collections.Generic;
using System.Linq;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeMethodCallExpression : FlowTypeExpression
    {
        public FlowTypeMethodCallExpression(FlowTypeExpression subject, string methodName, params FlowTypeType[] arguments)
        {
            Subject = subject;
            MethodName = methodName;
            Arguments.AddRange(arguments);
        }

        public FlowTypeExpression Subject { get; set; }
        public string MethodName { get; set; }
        public List<FlowTypeType> Arguments { get; } = new List<FlowTypeType>();

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("{0}.{1}({2})", Subject.GenerateCode(context), MethodName, string.Join(", ", Arguments.Select(x => x.GenerateCode(context))));
        }
    }
}