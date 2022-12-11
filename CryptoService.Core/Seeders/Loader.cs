using CryptoService.Core.Repositories;

namespace CryptoService.Core.Seeders
{
    public abstract class Loader<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Loader(IRepository<T> repository)
        {
            _repository = repository;
        }

        protected abstract IEnumerable<T> GetData();
        public async Task Initialize()
        {
            IEnumerable<T> data = GetData();
            await _repository.BatchAdd(data);
        }
    }
}
