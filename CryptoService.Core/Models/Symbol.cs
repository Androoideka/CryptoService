using CryptoService.Core.Models;

namespace CryptoService.Models
{
    public class Symbol : Entity
    {
        public Symbol(long id, string name, string ticker) : base(id)
        {
            Name = name;
            Ticker = ticker;
        }

        public string Name { get; set; }
        public string Ticker { get; set; }

        public ICollection<PriceData> Prices { get; set; } = new List<PriceData>();
    }
}
