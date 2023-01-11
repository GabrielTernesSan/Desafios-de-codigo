using ZeDelivery.Domain.Enum;

namespace ZeDelivery.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public ETipo Tipo { get; private set; }
        public List<double> Coordenada { get; private set; }

        public Endereco(ETipo tipo, List<double> coordenada)
        {
            Tipo = tipo;
            Coordenada = coordenada;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Coordenada; 
        }
    }
}
