using CryptoService.Core.Models;
using CryptoService.Core.Repositories;
using CryptoService.Infrastructure.Data;

namespace CryptoService.Infrastructure.Repositories
{
    public class SymbolRepository : Repository<Symbol>, ISymbolRepository
    {
        public SymbolRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Symbol>> GetByIds(IEnumerable<long> ids)
        {
            return base.GetWhere(symbol => ids.Contains(symbol.Id));
        }
    }
}
