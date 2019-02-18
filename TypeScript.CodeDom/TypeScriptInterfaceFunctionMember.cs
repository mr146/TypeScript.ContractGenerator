using System.Collections.Generic;
using System.Linq;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptInterfaceFunctionMember
    {
        public string Name { get; set; }
        public List<TypeScriptArgumentDeclaration> Arguments { get; } = new List<TypeScriptArgumentDeclaration>();
        public TypeScriptType Result { get; set; }

        public string GenerateCode(ICodeGenerationContext context)
        {
            return $"{Name}({GenerateArgumentListCode(context)}): {Result.GenerateCode(context)}";
        }

        private string GenerateArgumentListCode(ICodeGenerationContext context)
        {
            return string.Join(", ", Arguments.Select(x => x.GenerateCode(context)));
        }
    }
}