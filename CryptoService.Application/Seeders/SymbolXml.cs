using System.Xml.Serialization;

namespace CryptoService.Infrastructure.Seeders
{
    public class SymbolXml
    {
        [XmlAttribute("id")]
        public string id { get; set; }
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("ticker")]
        public string ticker { get; set; }
    }
}
