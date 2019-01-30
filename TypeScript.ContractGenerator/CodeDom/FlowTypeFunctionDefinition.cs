using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeFunctionDefinition : FlowTypeDefinition
    {
        public List<FlowTypeArgumentDeclaration> Arguments { get; } = new List<FlowTypeArgumentDeclaration>();
        public List<FlowTypeStatement> Body { get; } = new List<FlowTypeStatement>();
        public FlowTypeType Result { get; set; }
        public bool IsAsync { get; set; }

        private string GenerateArgumentListCode(ICodeGenerationContext context)
        {
            return string.Join(", ", Arguments.Select(x => x.GenerateCode(context)));
        }

        public override string GenerateCode(string name, ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            if(IsAsync)
            {
                result.Append("async ");
            }

            result.AppendFormat("{0}({1}): {2} {{", name, GenerateArgumentListCode(context), Result.GenerateCode(context)).Append(context.NewLine);
            foreach(var statement in Body)
            {
                result.AppendWithTab(context.Tab, statement.GenerateCode(context), context.NewLine).Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }
    }
}