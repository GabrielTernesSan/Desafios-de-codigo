using static Domain.Entities.MembrosLiga;

namespace Web.Interfaces
{
    public interface ILigaService
    {
        Task<LigaDaJustica> BuscarLigaDaJustica();
    }
}
