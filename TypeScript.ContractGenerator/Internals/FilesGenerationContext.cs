using System;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    public class FilesGenerationContext
    {
        private FilesGenerationContext([NotNull] string fileExtension, [NotNull] Func<string, string> headerGenerationFunc, JavaScriptTypeChecker javaScriptTypeChecker)
        {
            FileExtension = fileExtension;
            HeaderGenerationFunc = headerGenerationFunc;
            JavaScriptTypeChecker = javaScriptTypeChecker;
        }

        [NotNull]
        public static FilesGenerationContext Create(JavaScriptTypeChecker javaScriptTypeChecker)
        {
            switch (javaScriptTypeChecker)
            {
            case JavaScriptTypeChecker.Flow:
                return new FilesGenerationContext("js", marker => $"// @flow\n{marker}\n", javaScriptTypeChecker);
            case JavaScriptTypeChecker.TypeScript:
                return new FilesGenerationContext("ts", marker => $"{marker}\n// tslint:disable\n", javaScriptTypeChecker);
            default:
                throw new ArgumentOutOfRangeException(nameof(javaScriptTypeChecker), javaScriptTypeChecker, null);
            }
        }

        [NotNull]
        public string FileExtension { get; }

        [NotNull]
        public Func<string, string> HeaderGenerationFunc { get; }

        public JavaScriptTypeChecker JavaScriptTypeChecker { get; }
    }
}