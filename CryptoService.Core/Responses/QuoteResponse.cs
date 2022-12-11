namespace CryptoService.Core.Responses
{
    public class QuoteResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}
