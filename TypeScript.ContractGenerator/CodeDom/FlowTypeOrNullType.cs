using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public class FlowTypeOrNullType : FlowTypeUnionType
    {
        public FlowTypeOrNullType([NotNull] FlowTypeType innerType)
            : base(new[] {new FlowTypeBuildInType("null"), innerType})
        {
        }
    }
}