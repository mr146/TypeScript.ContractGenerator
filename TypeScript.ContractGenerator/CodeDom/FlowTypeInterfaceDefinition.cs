using System.Collections.Generic;
using System.Text;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeInterfaceDefinition : FlowTypeType
    {
        public List<FlowTypeInterfaceFunctionMember> Members { get; } = new List<FlowTypeInterfaceFunctionMember>();
        public List<FlowTypePropertyMember> PropertyMembers { get; } = new List<FlowTypePropertyMember>();

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.AppendFormat("{{").Append(context.NewLine);
            foreach(var member in Members)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context) + ";", context.NewLine).Append(context.NewLine);
            }

            foreach(var member in PropertyMembers)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context) + ";", context.NewLine).Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }
    }
}