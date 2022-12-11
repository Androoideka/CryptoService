using CryptoService.Core.Mappers;
using CryptoService.Core.Repositories;
using CryptoService.Core.Responses;
using CryptoService.Models;

namespace CryptoService.Core.Services
{
    public class CryptocurrencyService
    {
        private readonly ISymbolRepository _symbolRepo;
        public CryptocurrencyService(ISymbolRepository symbolRepo)
        {
            _symbolRepo = symbolRepo;
        }

        public async Task<IEnumerable<SymbolResponse>> GetAll()
        {
            IEnumerable<Symbol> symbols = await _symbolRepo.GetAll();
            IEnumerable<SymbolResponse> result = from symbol in symbols
                                                 select SymbolMapper.SymbolToResponse(symbol);
            return result;
        }
    }
}
