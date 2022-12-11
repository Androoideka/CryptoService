using CryptoService.Core.Models;
using CryptoService.Core.Responses;

namespace CryptoService.Core.Mappers
{
    public static class SymbolMapper
    {
        public static SymbolResponse SymbolToResponse(Symbol symbol)
        {
            SymbolResponse symbolResponse = new SymbolResponse();
            symbolResponse.Id = "tts-" + symbol.Id;
            symbolResponse.Name = symbol.Name;
            symbolResponse.Ticker = symbol.Ticker;
            return symbolResponse;
        }
    }
}
