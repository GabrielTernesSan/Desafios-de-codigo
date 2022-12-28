using static Domain.Entities.Vingadores;

namespace Web.Interfaces
{
    public interface IHeroiApi
    {
        Task<Root> Vingadores();
    }
}
