using ZeDelivery.Domain.ValueObjects;

namespace ZeDelivery.Domain.Entities
{
    public class Parceiro
    {
        public int Id { get; private set; }
        public string NomeEstabelecimento { get; private set; }
        public string NomeProprietario { get; private set; }
        public string Documento { get; private set; }
        public AreaCobertura AreaCobertura { get; }
        public Endereco Endereco { get; }

        public Parceiro(
            string nomeEstabelecimento, 
            string nomeProprietario, 
            string documento, 
            AreaCobertura areaCobertura, 
            Endereco endereco)
        {
            NomeEstabelecimento = nomeEstabelecimento;
            NomeProprietario = nomeProprietario;
            Documento = documento;
            AreaCobertura = areaCobertura;
            Endereco = endereco;
        }

        public Parceiro(
            int id, 
            string nomeEstabelecimento, 
            string nomeProprietario, 
            string documento, 
            AreaCobertura areaCobertura, 
            Endereco endereco) : this (nomeEstabelecimento, nomeProprietario, documento, areaCobertura, endereco)
        {
            Id = id;
        }
    }
}
