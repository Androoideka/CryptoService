using CryptoService.Core.Models;

namespace CryptoService.Core.Services
{
    public interface IPriceFinder
    {
        Task<IEnumerable<PriceData>> GetPriceDataFor(IEnumerable<Symbol> symbols);
    }
}
