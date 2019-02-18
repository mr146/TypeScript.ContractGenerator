using FluentAssertions;

using NUnit.Framework;

using SkbKontur.TypeScript.ContractGenerator.Tests.Types;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;

namespace SkbKontur.TypeScript.ContractGenerator.Tests
{
    public class GenericTypesTest
    {
        [Test]
        public void RootCantBeGenericType()
        {
            new TypeScriptGenerator(null, new[]{typeof(GenericRootType<CustomType>)})
                .Generate().Should().BeEmpty();
        }
    }
}