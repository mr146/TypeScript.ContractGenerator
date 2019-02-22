using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeTemplateStringLiteral : FlowTypeExpression
    {
        public FlowTypeTemplateStringLiteral(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public override string GenerateCode([NotNull] ICodeGenerationContext context)
        {
            return string.Format("`{0}`", Value);
        }
    }
}