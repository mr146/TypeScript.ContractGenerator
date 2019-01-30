using System.Linq;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeGenericType : FlowTypeType
    {
        public FlowTypeGenericType(FlowTypeType typeReference, FlowTypeType[] genericParameters)
        {
            TypeReference = typeReference;
            GenericParameters = genericParameters;
        }

        public FlowTypeType[] GenericParameters { get; private set; }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return TypeReference.GenerateCode(context) + "<" + string.Join(", ", GenericParameters.Select(x => x.GenerateCode(context))) + ">";
        }

        public FlowTypeType TypeReference { get; private set; }
    }
}