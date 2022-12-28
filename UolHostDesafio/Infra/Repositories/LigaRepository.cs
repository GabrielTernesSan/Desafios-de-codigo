using Domain.Repositories;

namespace Infra.Repositories
{
    public class LigaRepository : ILigaRespository
    {
        private readonly ContextMemory _contextMemory;

        public LigaRepository(ContextMemory contextMemory)
        {
            _contextMemory = contextMemory;
        }

        public async Task SalvarAsync(string liga)
        {
            var ligaDaJustica = new Tables.LigaDaJustica
            {
                codinome = liga
            };

            await _contextMemory.LigaDaJustica.AddAsync(ligaDaJustica);
            await _contextMemory.SaveChangesAsync();
        }
    }
}
