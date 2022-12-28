using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repositories
{
    public class VingadorRepository : IVingadorRepository
    {
        private readonly ContextMemory _contextMemory;

        public VingadorRepository(ContextMemory contextMemory)
        {
            _contextMemory = contextMemory;
        }

        public async Task SalvarAsync(Vingadores.Vingador vingador)
        {
            var cadastrarVingador = new Tables.Vingador
            {
                codinome = vingador.ToString()
            };

            await _contextMemory.AddAsync(cadastrarVingador);
            await _contextMemory.SaveChangesAsync();
        }
    }
}
