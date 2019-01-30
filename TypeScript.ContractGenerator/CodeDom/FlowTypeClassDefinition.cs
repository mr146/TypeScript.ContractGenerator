﻿using System.Collections.Generic;
using System.Text;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeClassDefinition
    {
        public List<FlowTypeClassMemberDefinition> Members { get; } = new List<FlowTypeClassMemberDefinition>();

        public FlowTypeType BaseClass { get; set; }

        public string GenerateBody(string name, ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.Append("class ");
            if(name != null)
                result.Append(name).Append(" ");
            if(BaseClass != null)
                result.Append("extends ").Append(BaseClass.GenerateCode(context)).Append(" ");
            result.Append("{").Append(context.NewLine);
            foreach(var member in Members)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context), context.NewLine)
                      .Append(context.NewLine)
                      .Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }
    }
}