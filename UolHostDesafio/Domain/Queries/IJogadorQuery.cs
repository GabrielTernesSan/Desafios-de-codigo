using Domain.Queries.Responses;

namespace Domain.Queries
{
    public interface IJogadorQuery
    {
        Task<IEnumerable<ObterJogadorResponse>> ObterJogadoresAsync();
        Task<ObterJogadorResponse> ObterJogadorIdAsync(int jogadorId);
    }
}
