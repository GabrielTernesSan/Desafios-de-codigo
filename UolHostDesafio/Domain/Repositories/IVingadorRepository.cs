using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVingadorRepository
    {
        Task SalvarAsync(Vingadores.Vingador vingador);
    }
}
