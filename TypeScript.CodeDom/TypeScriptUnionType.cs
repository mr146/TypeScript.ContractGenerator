using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptUnionType : TypeScriptType
    {
        public TypeScriptUnionType(TypeScriptType[] types)
        {
            this.types = types;
        }

        public override string GenerateCode(ICodeGenerationContext context)
        {
            return string.Join(" |" + context.NewLine, types.Select(x => x.GenerateCode(context)));
        }

        private readonly TypeScriptType[] types;
    }
}