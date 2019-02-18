﻿using System.Collections.Generic;
using System.Text;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptTypeDefintion : TypeScriptType
    {
        public List<TypeScriptTypeMemberDeclarationBase> Members { get; } = new List<TypeScriptTypeMemberDeclarationBase>();

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.AppendFormat("{{").Append(context.NewLine);
            foreach(var member in Members)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context), context.NewLine).Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }
    }
}