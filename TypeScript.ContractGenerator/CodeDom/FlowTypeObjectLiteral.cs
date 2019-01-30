using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeObjectLiteral : FlowTypeExpression
    {
        public FlowTypeObjectLiteral(IEnumerable<FlowTypeObjectLiteralInitializer> properties)
        {
            this.Properties = properties.ToList();
        }

        public List<FlowTypeObjectLiteralInitializer> Properties { get; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.Append("{").Append(context.NewLine);
            var propertiesString = string.Join("," + context.NewLine, Properties.Select(x => x.GenerateCode(context)));
            if(propertiesString.Length > 0)
                propertiesString += ",";
            result.AppendWithTab(context.Tab, propertiesString, context.NewLine).Append(context.NewLine);
            result.Append("}");
            return result.ToString();
        }
    }
}