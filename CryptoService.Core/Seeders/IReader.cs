namespace CryptoService.Core.Seeders
{
    public enum FileType
    {
        XML, JSON, YAML
    }

    public interface IReader<T> where T : class
    {
        IEnumerable<T> Read(string file);
        FileType GetExtension();
    }
}
