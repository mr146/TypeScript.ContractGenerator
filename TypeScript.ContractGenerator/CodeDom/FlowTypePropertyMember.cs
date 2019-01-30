namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypePropertyMember
    {
        public string Name { get; set; }
        public FlowTypeType Result { get; set; }

        public string GenerateCode(ICodeGenerationContext context)
        {
            return $"{Name}: {Result.GenerateCode(context)}";
        }
    }
}