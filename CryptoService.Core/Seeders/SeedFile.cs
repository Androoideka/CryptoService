namespace CryptoService.Core.Seeders
{
    public class SeedFile
    {
        public SeedFile(string path, FileType type)
        {
            Path = path;
            Type = type;
        }

        public string Path { get; set; }
        public FileType Type { get; set; }
    }
}
