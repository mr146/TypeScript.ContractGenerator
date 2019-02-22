using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public abstract class FlowTypeExpression
    {
        public abstract string GenerateCode([NotNull] ICodeGenerationContext context);
    }
}