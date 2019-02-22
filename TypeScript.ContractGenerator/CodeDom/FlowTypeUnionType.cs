using System.Linq;

using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeUnionType : FlowTypeType
    {
        public FlowTypeUnionType([NotNull, ItemNotNull] FlowTypeType[] types)
        {
            this.types = types;
        }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var resultWithNewLines = string.Join(" |" + context.NewLine, types.Select(x => x.GenerateCode(context)));
            if (resultWithNewLines.Length < 90)
            {
                return string.Join(" | ", types.Select(x => x.GenerateCode(context)));
            }
            return resultWithNewLines;
        }

        private readonly FlowTypeType[] types;
    }
}