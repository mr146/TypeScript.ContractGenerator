﻿using System;

using SKBKontur.Catalogue.TypeScript.CodeDom;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals
{
    public class DefaultCodeGenerationContext : ICodeGenerationContext
    {
        public DefaultCodeGenerationContext(JavaScriptTypeChecker typeChecker)
        {
            TypeChecker = typeChecker;
        }

        public JavaScriptTypeChecker TypeChecker { get; }

        public string Tab => "    ";
        public string NewLine => "\n";

        public string GetReferenceFromUnitToAnother(TypeScriptUnit currentUnit, TypeScriptUnit targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit.Path);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit.Path);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }

        public string GetReferenceFromUnitToAnother(string currentUnit, string targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }
    }
}