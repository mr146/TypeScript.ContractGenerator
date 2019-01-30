using System;
using System.Linq;
using System.Text;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeEnumDefinition : FlowTypeType
    {
        public FlowTypeEnumDefinition(Type enumType)
        {
            this.enumType = enumType;
        }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var enumValues = Enum.GetNames(enumType).ToArray();
            var result = new StringBuilder();
            result.AppendFormat("{{").Append(context.NewLine);
            foreach(var value in enumValues)
            {
                result.AppendWithTab(context.Tab, $"{value} = \"{value}\"" + ",", context.NewLine).Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }

        private readonly Type enumType;
    }
}