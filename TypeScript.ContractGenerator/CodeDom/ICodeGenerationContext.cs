using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public interface ICodeGenerationContext
    {
        JavaScriptTypeChecker TypeChecker { get; }

        [NotNull]
        string Tab { get; }

        [NotNull]
        string NewLine { get; }

        string GetReferenceFromUnitToAnother([NotNull] string currentUnit, [NotNull] string targetUnit);
    }
}