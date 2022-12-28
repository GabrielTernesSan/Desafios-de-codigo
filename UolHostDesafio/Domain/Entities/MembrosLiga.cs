using System.Xml.Serialization;

namespace Domain.Entities
{
    public class MembrosLiga
    {
        public class Codinomes
        {
            [XmlElement(ElementName = "codinome")]
            public List<string> Codinome { get; set; }
        }

        [XmlRoot(ElementName = "liga_da_justica")]
        public class LigaDaJustica
        {
            [XmlElement(ElementName = "codinomes")]
            public Codinomes Codinomes { get; set; }
        }
    }
}
