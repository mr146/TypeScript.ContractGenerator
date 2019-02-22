using System;
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

namespace SkbKontur.TypeScript.ContractGenerator
{
    public static class FlowTypeGeneratorHelpers
    {
        public static (bool, Type) ProcessNullable([CanBeNull] ICustomAttributeProvider attributeContainer, [NotNull] Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var underlyingType = type.GetGenericArguments()[0];
                return (true, underlyingType);
            }
            if (attributeContainer != null && type.IsClass && attributeContainer.GetCustomAttributes(true).All(x => x.GetType().Name != "NotNullAttribute"))
                return (true, type);
            return (false, type);
        }
    }
}