using CryptoService.Core.Models;
using CryptoService.Core.Responses;

namespace CryptoService.Core.Mappers
{
    public static class QuoteMapper
    {
        public static QuoteResponse PriceDataToQuote(PriceData priceData)
        {
            QuoteResponse quote = new QuoteResponse();
            quote.Id = "tts-" + priceData.Symbol.Id;
            quote.Name = priceData.Symbol.Name;
            quote.Ticker = priceData.Symbol.Ticker;
            quote.Last = priceData.Last;
            quote.High = priceData.High;
            quote.Low = priceData.Low;
            quote.Bid = priceData.Bid;
            quote.Ask = priceData.Ask;
            return quote;
        }
    }
}
