using static Domain.Entities.Vingadores;

namespace Web.Interfaces
{
    public interface IVingadorService
    {
        Task<Root> BuscarVingadores();
    }
}
