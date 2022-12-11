namespace CryptoService.Core.Models
{
    public class PriceData : Entity
    {
        public PriceData(decimal last, decimal high, decimal low, decimal bid, decimal ask)
        {
            FetchedAt = DateTime.Now;
            Last = last;
            High = high;
            Low = low;
            Bid = bid;
            Ask = ask;
        }

        public DateTime FetchedAt { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }

        public long SymbolId { get; set; }
        public Symbol Symbol { get; set; }
    }
}
