using Domain.Queries.Responses;

namespace Domain.Queries
{
    public interface ILigaQuery
    {
        Task<IEnumerable<ObterLigaResponse>> ObterLigaDaJustica();
    }
}
