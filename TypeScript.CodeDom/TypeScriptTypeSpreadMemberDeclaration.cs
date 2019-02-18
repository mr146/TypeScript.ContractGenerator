﻿namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptTypeSpreadMemberDeclaration : TypeScriptTypeMemberDeclarationBase
    {
        public TypeScriptType Type { get; set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Format("...{0};", Type.GenerateCode(context));
        }
    }
}