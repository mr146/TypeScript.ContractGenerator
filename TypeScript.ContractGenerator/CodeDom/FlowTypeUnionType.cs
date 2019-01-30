﻿using System.Linq;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeUnionType : FlowTypeType
    {
        public FlowTypeUnionType(FlowTypeType[] types)
        {
            this.types = types;
        }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Join(" |" + context.NewLine, types.Select(x => x.GenerateCode(context)));
        }

        private readonly FlowTypeType[] types;
    }
}