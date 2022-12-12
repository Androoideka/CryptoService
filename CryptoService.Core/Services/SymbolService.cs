using CryptoService.Core.Mappers;
using CryptoService.Core.Models;
using CryptoService.Core.Repositories;
using CryptoService.Core.Requests;
using CryptoService.Core.Responses;

namespace CryptoService.Core.Services
{
    public class SymbolService
    {
        private readonly ISymbolRepository _symbolRepo;
        private readonly IPriceFinder _priceFinder;
        public SymbolService(ISymbolRepository symbolRepo, IPriceFinder priceFinder)
        {
            _symbolRepo = symbolRepo;
            _priceFinder = priceFinder;
        }

        public async Task<IEnumerable<SymbolResponse>> GetAll()
        {
            IEnumerable<Symbol> symbols = await _symbolRepo.GetAll();
            IEnumerable<SymbolResponse> result = from symbol in symbols
                                                 select SymbolMapper.SymbolToResponse(symbol);
            return result;
        }

        public async Task<IEnumerable<QuoteResponse>> GetQuotes(QuoteRequest quoteRequest)
        {
            IEnumerable<Symbol> symbols = await _symbolRepo.GetWhere(symbol => quoteRequest.Ids.Contains(symbol.Id));
            IEnumerable<PriceData> priceData = await _priceFinder.GetPriceDataFor(symbols);
            IEnumerable<QuoteResponse> result = from price in priceData
                                                select QuoteMapper.PriceDataToQuote(price);
            return result;
        }
    }
}
