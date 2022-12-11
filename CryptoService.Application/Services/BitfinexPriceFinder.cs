using CryptoService.Core.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CryptoService.Infrastructure.Services
{
    public class BitfinexPriceFinder : HttpPriceFinder
    {
        public BitfinexPriceFinder(HttpClient client) : base(client, "https://api-pub.bitfinex.com/v2/tickers")
        {
        }

        /*
         * TICKER
         * BID
         * BID SIZE
         * ASK
         * ASK SIZE
         * DAILY CHANGE
         * DAILY CHANGE RELATIVE
         * LAST PRICE
         * VOLUME
         * HIGH
         * LOW
         */

        public override async Task<IEnumerable<PriceData>> GetPriceDataFor(IEnumerable<Symbol> symbols)
        {
            Dictionary<string, Symbol> tickerToSymbol = symbols.ToDictionary(symbol => "t" + symbol.Ticker);
            string commaSeparatedList = String.Join(",", tickerToSymbol.Keys);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, commaSeparatedList);
            HttpResponseMessage response = await _httpClient.GetAsync("?symbols=" + commaSeparatedList);
            response.EnsureSuccessStatusCode();
            string body = await response.Content.ReadAsStringAsync();
            return ParseJson(body, tickerToSymbol);
        }

        protected virtual IEnumerable<PriceData> ParseJson(String body, Dictionary<string, Symbol> tickerToSymbol)
        {
            IEnumerable<PriceData> priceData = new List<PriceData>();
            JsonArray results = JsonSerializer.Deserialize<JsonArray>(body);
            foreach (var result in results)
            {
                JsonArray data = result.AsArray();
                PriceData price = JsonToPriceData(data, tickerToSymbol);
                priceData = priceData.Append(price);
            }
            return priceData;
        }

        protected virtual PriceData JsonToPriceData(JsonArray data, Dictionary<string, Symbol> tickerToSymbol)
        {
            string ticker = data[0].GetValue<string>();
            decimal bid = data[1].GetValue<decimal>();
            decimal ask = data[3].GetValue<decimal>();
            decimal last = data[7].GetValue<decimal>();
            decimal high = data[9].GetValue<decimal>();
            decimal low = data[10].GetValue<decimal>();
            PriceData priceData = new PriceData(last, high, low, bid, ask);
            priceData.Symbol = tickerToSymbol[ticker];
            return priceData;
        }
    }
}
