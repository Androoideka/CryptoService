using System.Xml.Serialization;

namespace CryptoService.Infrastructure.Seeders
{
    [XmlRoot(ElementName = "SymbolList")]
    public class SymbolList
    {
        [XmlElement("Symbol")]
        public List<SymbolXml> symbols { get; set; }
    }
}
