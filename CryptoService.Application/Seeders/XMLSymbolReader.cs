using CryptoService.Core.Models;
using CryptoService.Core.Seeders;
using System.Xml.Serialization;

namespace CryptoService.Infrastructure.Seeders
{
    public class XMLSymbolReader : IReader<Symbol>
    {
        public FileType GetExtension()
        {
            return FileType.XML;
        }

        public IEnumerable<Symbol> Read(string file)
        {
            XmlSerializer reader = new XmlSerializer(typeof(SymbolList));
            StreamReader fileStream = new StreamReader(file);
            SymbolList symbolsXml = (SymbolList)reader.Deserialize(fileStream);
            fileStream.Close();
            IEnumerable<Symbol> symbols = from symbol in symbolsXml.symbols
                                          let id = Convert.ToInt64(symbol.id.Substring(4))
                                          select new Symbol(id, symbol.name, symbol.ticker);
            return symbols;
        }
    }
}
