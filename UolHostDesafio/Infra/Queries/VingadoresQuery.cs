using Domain.Queries;
using Domain.Queries.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class VingadoresQuery : IVingadoresQuery
    {

        private readonly ContextMemory _context;

        public VingadoresQuery(ContextMemory context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ObterVingadoresResponse>> ObterVingadores()
        {
            var vingadores = await (from v in _context.Vingadores
                                    select new ObterVingadoresResponse
                                    {
                                        Id = v.Id,
                                        Codinome = v.codinome
                                    }).ToListAsync();
            return vingadores;
        }
    }
}
