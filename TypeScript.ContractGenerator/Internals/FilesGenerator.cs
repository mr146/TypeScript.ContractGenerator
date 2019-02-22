using System.IO;

using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    internal static class FilesGenerator
    {
        public static void GenerateFiles([NotNull] string targetDir, [NotNull] DefaultFlowTypeGeneratorOutput output, [NotNull] FilesGenerationContext filesGenerationContext)
        {
            DeleteFiles(targetDir, $"*.{filesGenerationContext.FileExtension}");
            Directory.CreateDirectory(targetDir);
            foreach (var unit in output.Units)
            {
                var targetFileName = GetUnitTargetFileName(targetDir, unit, filesGenerationContext.FileExtension);

                EnsureDirectoryExists(targetFileName);

                File.WriteAllText(targetFileName, filesGenerationContext.HeaderGenerationFunc(generatedContentMarkerString));
                File.AppendAllText(targetFileName, unit.GenerateCode(new DefaultCodeGenerationContext(filesGenerationContext.JavaScriptTypeChecker)));
            }
        }

        [NotNull]
        private static string GetUnitTargetFileName([NotNull] string targetDir, [NotNull] FlowTypeUnit unit, [NotNull] string fileExtension)
        {
            return Path.Combine(targetDir, $"{unit.Path}.{fileExtension}");
        }

        private static void EnsureDirectoryExists([NotNull] string targetFileName)
        {
            var targetDirectoryName = Path.GetDirectoryName(targetFileName);
            if (!string.IsNullOrEmpty(targetDirectoryName))
                Directory.CreateDirectory(targetDirectoryName);
        }

        private static void DeleteFiles([NotNull] string targetDir, [NotNull] string searchPattern)
        {
            var files = Directory.GetFiles(targetDir, searchPattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (File.ReadAllText(file).Contains(generatedContentMarkerString))
                {
                    File.Delete(file);
                }
            }
        }

        private static readonly string generatedContentMarkerString = "// TypeScriptContractGenerator's generated content";
    }
}