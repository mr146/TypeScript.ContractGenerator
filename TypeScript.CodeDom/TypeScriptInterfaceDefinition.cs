using System.Collections.Generic;
using System.Text;

namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptInterfaceDefinition : TypeScriptType
    {
        public List<TypeScriptInterfaceFunctionMember> Members { get; } = new List<TypeScriptInterfaceFunctionMember>();
        public List<TypeScriptPropertyMember> PropertyMembers { get; } = new List<TypeScriptPropertyMember>();

        public override string GenerateCode(ICodeGenerationContext context)
        {
            var result = new StringBuilder();
            result.AppendFormat("{{").Append(context.NewLine);
            foreach(var member in Members)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context) + ";", context.NewLine).Append(context.NewLine);
            }

            foreach(var member in PropertyMembers)
            {
                result.AppendWithTab(context.Tab, member.GenerateCode(context) + ";", context.NewLine).Append(context.NewLine);
            }

            result.Append("}");
            return result.ToString();
        }
    }
}