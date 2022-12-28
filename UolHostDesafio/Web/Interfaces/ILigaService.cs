using Domain.Entities;
using static Domain.Entities.Liga;

namespace Web.Interfaces
{
    public interface ILigaService
    {
        Task<LigaDaJustica> BuscarLigaDaJustica();
    }
}
