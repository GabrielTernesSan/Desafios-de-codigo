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

        public async Task SalvarAsync(string vingador)
        {
            var cadastrarVingador = new Tables.Vingador
            {
                codinome = vingador
            };

            await _contextMemory.Vingadores.AddAsync(cadastrarVingador);
            await _contextMemory.SaveChangesAsync();
        }
    }
}
