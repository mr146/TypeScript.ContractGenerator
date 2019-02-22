using System;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    public class DefaultCodeGenerationContext : ICodeGenerationContext
    {
        public DefaultCodeGenerationContext(JavaScriptTypeChecker typeChecker)
        {
            TypeChecker = typeChecker;
        }

        public JavaScriptTypeChecker TypeChecker { get; }

        [NotNull]
        public string Tab => "    ";

        [NotNull]
        public string NewLine => "\n";

        [NotNull]
        public string GetReferenceFromUnitToAnother([NotNull] FlowTypeUnit currentUnit, [NotNull] FlowTypeUnit targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit.Path);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit.Path);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }

        [NotNull]
        public string GetReferenceFromUnitToAnother(string currentUnit, string targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }
    }
}