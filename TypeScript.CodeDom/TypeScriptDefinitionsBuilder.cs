namespace SKBKontur.Catalogue.TypeScript.CodeDom
{
    public class TypeScriptDefinitionsBuilder
    {
        public TypeScriptFileBuilder AddFile(string relativeFilename)
        {
            return new TypeScriptFileBuilder();
        }
    }
}