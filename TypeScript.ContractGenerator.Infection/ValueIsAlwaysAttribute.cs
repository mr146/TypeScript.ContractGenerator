using System;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Infection
{
    public class ValueIsAlwaysAttribute : Attribute
    {
        public ValueIsAlwaysAttribute(string enumValue)
        {
            EnumValue = enumValue;
        }

        public string EnumValue { get; }
    }
}