﻿namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public abstract class TypeScriptStatement
    {
        public abstract string GenerateCode(ICodeGenerationContext context);
    }
}