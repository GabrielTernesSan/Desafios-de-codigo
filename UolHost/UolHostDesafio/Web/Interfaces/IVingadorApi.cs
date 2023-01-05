using static Domain.Entities.Vingadores;

namespace Web.Interfaces
{
    public interface IVingadorApi
    {
        Task<Root> Vingadores();
    }
}
