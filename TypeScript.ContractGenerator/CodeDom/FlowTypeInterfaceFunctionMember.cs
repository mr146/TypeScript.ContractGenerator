using System.Collections.Generic;
using System.Linq;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeInterfaceFunctionMember
    {
        public string Name { get; set; }
        public List<FlowTypeArgumentDeclaration> Arguments { get; } = new List<FlowTypeArgumentDeclaration>();
        public FlowTypeType Result { get; set; }

        public string GenerateCode(ICodeGenerationContext context)
        {
            return $"{Name}({GenerateArgumentListCode(context)}): {Result.GenerateCode(context)}";
        }

        private string GenerateArgumentListCode(ICodeGenerationContext context)
        {
            return string.Join(", ", Arguments.Select(x => x.GenerateCode(context)));
        }
    }
}