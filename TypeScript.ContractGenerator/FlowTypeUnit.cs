using System;
using System.Collections.Generic;
using System.Text;

using JetBrains.Annotations;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;
using SkbKontur.TypeScript.ContractGenerator.Internals;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public class FlowTypeUnit
    {
        [NotNull]
        public string Path { get; set; }

        [NotNull, ItemNotNull]
        public IEnumerable<FlowTypeImportStatement> Imports => imports.Values;

        [NotNull, ItemNotNull]
        public List<FlowTypeStatement> Body { get; } = new List<FlowTypeStatement>();

        [NotNull]
        public FlowTypeTypeReference AddTypeImport([NotNull] Type sourceType, [NotNull] FlowTypeTypeDeclaration typeDeclaration, [NotNull] FlowTypeUnit sourceUnit)
        {
            if (sourceUnit != this && !imports.ContainsKey(sourceType))
            {
                imports.Add(sourceType, new FlowTypeImportFromUnitStatement
                    {
                        TypeName = typeDeclaration.Name,
                        CurrentUnit = this,
                        TargetUnit = sourceUnit,
                    });
            }
            return new FlowTypeTypeReference(typeDeclaration.Name);
        }

        public FlowTypeVariableReference AddDefaultSymbolImport([NotNull] string localName, [NotNull] string path)
        {
            var importedSymbol = new ImportedSymbol("default", localName, path);
            if (!symbolImports.ContainsKey(importedSymbol))
            {
                symbolImports.Add(importedSymbol, new FlowTypeImportDefaultFromPathStatement
                    {
                        TypeName = localName,
                        CurrentUnit = this,
                        PathToUnit = path,
                    });
            }
            return new FlowTypeVariableReference(localName);
        }

        public string GenerateCode(DefaultCodeGenerationContext context)
        {
            var result = new StringBuilder();

            foreach (var import in Imports)
            {
                result.Append(import.GenerateCode(context)).Append(context.NewLine);
            }
            foreach (var import in symbolImports.Values)
            {
                result.Append(import.GenerateCode(context)).Append(context.NewLine);
            }
            result.Append(context.NewLine);

            foreach (var statement in Body)
            {
                result.Append(statement.GenerateCode(context)).Append(context.NewLine);
            }

            return result.ToString();
        }

        private readonly Dictionary<Type, FlowTypeImportStatement> imports = new Dictionary<Type, FlowTypeImportStatement>();
        private readonly Dictionary<ImportedSymbol, FlowTypeImportStatement> symbolImports = new Dictionary<ImportedSymbol, FlowTypeImportStatement>();
    }
}