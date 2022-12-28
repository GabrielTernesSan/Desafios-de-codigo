using Domain.Entities;

namespace Domain.Repositories
{
    public interface IJogadorRepository
    {
        Task SalvarAsync(Jogador jogador);
        Task AtualizarJogadorAsync(Jogador JogadorAtualizado);
        Task ExcluirJogadorAsync(int jogadorId);
        Task<Jogador> ObterJogadorAsync(int jogadorId);
    }
}
