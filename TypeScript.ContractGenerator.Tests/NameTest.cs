using FluentAssertions;

using NUnit.Framework;

using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Extensions;

namespace SkbKontur.TypeScript.ContractGenerator.Tests
{
    public class NameTest
    {
        [Test]
        public void Test()
        {
            "ASyncMDNs".ToLowerCamelCase().Should().Be("aSyncMDNs");
            "URILocator".ToLowerCamelCase().Should().Be("uriLocator");
            "AbIRabc".ToLowerCamelCase().Should().Be("abIRabc");
            "MySQLType".ToLowerCamelCase().Should().Be("mySQLType");
            "XMLHttpRequest".ToLowerCamelCase().Should().Be("xmlHttpRequest");
            "LaURL".ToLowerCamelCase().Should().Be("laURL");
        }
    }
}