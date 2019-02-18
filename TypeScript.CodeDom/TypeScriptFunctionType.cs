﻿using System.Collections.Generic;
using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptFunctionType : TypeScriptType
    {
        public List<TypeScriptArgumentDeclaration> Arguments { get; } = new List<TypeScriptArgumentDeclaration>();
        public TypeScriptType Result { get; set; }

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