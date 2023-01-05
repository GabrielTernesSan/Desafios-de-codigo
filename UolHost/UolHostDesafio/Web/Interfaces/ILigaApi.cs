
using static Domain.Entities.MembrosLiga;

namespace Web.Interfaces
{
    public interface ILigaApi
    {
        Task<LigaDaJustica> Liga();
    }
}
