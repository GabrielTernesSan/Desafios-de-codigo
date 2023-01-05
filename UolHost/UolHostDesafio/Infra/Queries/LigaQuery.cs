using Domain.Queries;
using Domain.Queries.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class LigaQuery : ILigaQuery
    {

        private readonly ContextMemory _context;

        public LigaQuery(ContextMemory context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ObterLigaResponse>> ObterLigaDaJustica()
        {
            var liga = await (from v in _context.LigaDaJustica
                                   select new ObterLigaResponse
                                   {
                                       Id = v.Id,
                                       Codinome = v.codinome
                                   }).ToListAsync();
            return liga;
        }
    }
}
