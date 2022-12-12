using CryptoService.Core.Repositories;

namespace CryptoService.Core.Seeders
{
    public class FileLoader<T> : Loader<T> where T : class
    {
        protected readonly IReader<T> _reader;
        protected readonly string _path;

        public FileLoader(IRepository<T> repository, IEnumerable<IReader<T>> readers, SeedFile metadata) : base(repository)
        {
            Dictionary<FileType, IReader<T>> extensionReaders = readers.ToDictionary(reader => reader.GetExtension());
            _reader = extensionReaders[metadata.Type];
            _path = metadata.Path;
        }

        protected override IEnumerable<T> GetData()
        {
            /*if (!File.Exists(_path))
            {
                throw new Exception("No file found!");
            }*/
            return _reader.Read(_path);
        }
    }
}
