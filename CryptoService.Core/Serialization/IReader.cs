namespace CryptoService.Core.Serialization
{
    public interface IReader
    {
        T ReadFromFile<T>(String filePath) where T : class;
    }
}
