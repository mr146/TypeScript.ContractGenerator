﻿using System.Collections.Generic;
using System.Linq;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeFunctionType : FlowTypeType
    {
        public List<FlowTypeArgumentDeclaration> Arguments { get; } = new List<FlowTypeArgumentDeclaration>();
        public FlowTypeType Result { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("({0}) => {1}", GenerateArgumentListCode(context), Result.GenerateCode(context));
        }

        private string GenerateArgumentListCode(ICodeGenerationContext context)
        {
            return string.Join(", ", Arguments.Select(x => x.GenerateCode(context)));
        }
    }
}