using CryptoService.Core.Models;

namespace CryptoService.Core.Repositories
{
    public interface ISymbolRepository : IRepository<Symbol>
    {
        Task<IEnumerable<Symbol>> GetByIds(IEnumerable<long> ids);
    }
}
