using Domain.Enums;

namespace Domain.Queries.Responses
{
    public class ObterJogadorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
        public string Codinome { get; set; }
        public EGrupo Grupo { get; set; }
    }
}
