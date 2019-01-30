using System.IO;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    internal static class FilesGenerator
    {
        public static void GenerateFiles(string targetDir, DefaultFlowTypeGeneratorOutput output)
        {
            Directory.CreateDirectory(targetDir);
            var files = Directory.GetFiles(targetDir, "*.js", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if(File.ReadAllText(file).Contains(generatedContentMarkerString))
                {
                    File.Delete(file);
                }
            }

            foreach(var unit in output.Units)
            {
                var targetFileName = Path.Combine(targetDir, unit.Path + ".js");
                Directory.CreateDirectory(Path.GetDirectoryName(targetFileName));
                File.WriteAllText(targetFileName, "// @flow" + "\n");
                File.AppendAllText(targetFileName, generatedContentMarkerString + "\n");
                File.AppendAllText(targetFileName, unit.GenerateCode(new DefaultCodeGenerationContext(JavaScriptTypeChecker.Flow)));
            }
        }

        public static void GenerateTypeScriptFiles(string targetDir, DefaultFlowTypeGeneratorOutput output)
        {
            Directory.CreateDirectory(targetDir);
            var files = Directory.GetFiles(targetDir, "*.ts?", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if(File.ReadAllText(file).Contains(generatedContentMarkerString))
                {
                    File.Delete(file);
                }
            }

            foreach(var unit in output.Units)
            {
                var targetFileName = Path.Combine(targetDir, unit.Path + ".ts");
                Directory.CreateDirectory(Path.GetDirectoryName(targetFileName));
                File.AppendAllText(targetFileName, generatedContentMarkerString + "\n");
                File.AppendAllText(targetFileName, "// tslint:disable\n");
                File.AppendAllText(targetFileName, unit.GenerateCode(new DefaultCodeGenerationContext(JavaScriptTypeChecker.TypeScript)));
            }
        }

        private static readonly string generatedContentMarkerString = @"// FlowTypeContractGenerator's generated content";
    }
}