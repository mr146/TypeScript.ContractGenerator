using System;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

using SkbKontur.TypeScript.ContractGenerator.Tests.CustomTypeGenerators;
using SkbKontur.TypeScript.ContractGenerator.Tests.Types;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core;

namespace SkbKontur.TypeScript.ContractGenerator.Tests
{
    public class EndToEndTests : FlowTypeTestBase
    {
        public EndToEndTests(JavaScriptTypeChecker javaScriptTypeChecker)
            : base(javaScriptTypeChecker)
        {
        }

        [TestCase(typeof(NamingRootType), "type-names.expected")]
        [TestCase(typeof(SimpleRootType), "simple-types.expected")]
        [TestCase(typeof(SimpleNullableRootType), "nullable-types.expected")]
        [TestCase(typeof(EnumContainingRootType), "enum-types.expected")]
        [TestCase(typeof(ComplexRootType), "complex-types.expected")]
        [TestCase(typeof(GenericRootType<>), "generic-root.expected")]
        [TestCase(typeof(GenericContainingRootType), "generic-types.expected")]
        [TestCase(typeof(ArrayRootType), "array-types.expected")]
        [TestCase(typeof(NotNullRootType), "notnull-types.expected")]
        public void GenerateCodeTest(Type rootType, string expectedFileName)
        {
            var generatedCode = GenerateCode(rootType).Single().Replace("\r\n", "\n");
            var expectedCode = GetExpectedCode($"SimpleGenerator/{expectedFileName}");
            generatedCode.Should().Be(expectedCode);
        }

        [TestCase(typeof(FlatTypeLocator))]
        [TestCase(typeof(SimpleStructureTypeLocator))]
        public void GenerateFilesTest(Type type)
        {
            var rootTypes = new[] {typeof(CommonUsingRootType), typeof(CommonUsingRootType2), typeof(CommonUsingRootType3)};
            GenerateFiles((ICustomTypeGenerator)Activator.CreateInstance(type), $"{type.Name}.Actual", rootTypes);
            CheckDirectoriesEquivalence($"Files/{type.Name}.Expected", $"{type.Name}.Actual");
        }

        [TestCase(typeof(SimpleRootType), "simple-types.expected")]
        [TestCase(typeof(SimpleNullableRootType), "nullable-types.expected")]
        [TestCase(typeof(ArrayRootType), "array-types.expected")]
        public void CustomGeneratorTest(Type rootType, string expectedFileName)
        {
            var generatedCode = GenerateCode(new TestCustomTypeGenerator(), rootType).Single().Replace("\r\n", "\n");
            var expectedCode = GetExpectedCode($"CustomGenerator/{expectedFileName}");
            generatedCode.Should().Be(expectedCode);
        }
    }
}