using System;
using System.Linq;
using System.Text;

using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator.CodeDom
{
    public static class StringBuilderUtils
    {
        [NotNull]
        public static StringBuilder AppendWithTab([NotNull] this StringBuilder stringBuilder, [NotNull] string tab, [NotNull] string lines, [NotNull] string newLine)
        {
            return stringBuilder.Append(string.Join(newLine, lines.Split(new[] {newLine}, StringSplitOptions.None).Select(x => tab + x)));
        }
    }
}