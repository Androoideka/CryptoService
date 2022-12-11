using CryptoService.Core.Models;
using CryptoService.Core.Services;

namespace CryptoService.Infrastructure.Services
{
    public abstract class HttpPriceFinder : IPriceFinder
    {
        protected readonly HttpClient _httpClient;

        protected HttpPriceFinder(HttpClient client, string baseUrl)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public abstract Task<IEnumerable<PriceData>> GetPriceDataFor(IEnumerable<Symbol> symbols);
    }
}
