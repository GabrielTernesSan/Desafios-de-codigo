using System.Xml.Serialization;

namespace Domain.Entities
{
    public class Liga
    {
        public Liga(string codinome)
        {
            Codinome = codinome;
        }

        public string Codinome { get; set; }
    }
}
