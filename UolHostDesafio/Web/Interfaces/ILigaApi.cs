using Domain.Entities;
using static Domain.Entities.Liga;

namespace Web.Interfaces
{
    public interface ILigaApi
    {
        Task<LigaDaJustica> Liga();
    }
}
