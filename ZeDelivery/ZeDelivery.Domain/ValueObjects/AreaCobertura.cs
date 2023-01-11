using ZeDelivery.Domain.Enum;

namespace ZeDelivery.Domain.ValueObjects
{
    public class AreaCobertura : ValueObject
    {
        public ETipo Tipo { get; private set; }
        public List<List<List<List<double>>>> Coordenadas { get; private set; }

        public AreaCobertura(ETipo tipo, List<List<List<List<double>>>> coordenadas)
        {
            Tipo = tipo;
            Coordenadas = coordenadas;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Coordenadas; 
        }
    }
}
