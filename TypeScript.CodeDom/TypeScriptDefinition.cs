﻿namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public abstract class TypeScriptDefinition
    {
        public abstract string GenerateCode(string name, ICodeGenerationContext context);
    }
}