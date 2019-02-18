namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core
{
    public interface ITypeScriptUnitFactory
    {
        TypeScriptUnit GetOrCreateTypeUnit(string path);
    }
}