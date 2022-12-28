using Domain.Enums;

namespace Infra.Tables
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Codinome { get; set; }
        public EGrupo Grupo { get; set; }
    }
}
