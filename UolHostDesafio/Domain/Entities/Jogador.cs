using Domain.Enums;

namespace Domain.Entities
{
    public class Jogador
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Codinome { get; set; }
        public EGrupo Grupo { get; private set; }

        public Jogador(string nome, string email, string telefone, string codinome, EGrupo grupo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Codinome = codinome;
            Grupo = grupo;
        }

        public Jogador(string nome, string email, string telefone, EGrupo grupo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Grupo = grupo;
        }

        public Jogador(int id, string nome, string email, string telefone, string codinome, EGrupo grupo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Codinome = codinome;
            Grupo = grupo;
        }

    }
}
