namespace CryptoService.Core.Requests
{
    public class QuoteRequest
    {
        public QuoteRequest(IEnumerable<string> ids)
        {
            Ids = from id in ids
                  let trimmedId = id.Substring(4)
                  select Convert.ToInt64(trimmedId);
        }

        public IEnumerable<long> Ids { get; set; }
    }
}
