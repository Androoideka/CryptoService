using CryptoService.Core.Models;
using CryptoService.Core.Repositories;

namespace CryptoService.Core.Seeders
{
    public class TestLoader : Loader<Symbol>
    {
        public TestLoader(IRepository<Symbol> repository) : base(repository)
        {
        }

        protected override IEnumerable<Symbol> GetData()
        {
            IEnumerable<Symbol> data = new List<Symbol>();
            data = data.Append(new Symbol(5, "Bitcoin", "BTCUSD"));
            data = data.Append(new Symbol(6, "Ethereum", "ETCUSD"));
            return data;
        }
    }
}
