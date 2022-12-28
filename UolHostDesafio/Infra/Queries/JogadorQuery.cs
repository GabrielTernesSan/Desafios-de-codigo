using Domain.Queries;
using Domain.Queries.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class JogadorQuery : IJogadorQuery
    {

        private readonly Context _context;

        public JogadorQuery(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ObterJogadorResponse>> ObterJogadoresAsync()
        {
            var jogadores = await (from j in _context.Jogadores
                                   select new ObterJogadorResponse
                                   {
                                       Id = j.Id,
                                       Nome = j.Nome,
                                       Email = j.Email,
                                       telefone = j.Telefone,
                                       Codinome = j.Codinome,
                                       Grupo = j.Grupo
                                   }).ToListAsync();

            return jogadores;
        }

        public async Task<ObterJogadorResponse> ObterJogadorIdAsync(int jogadorId)
        {
            var jogador = await (from j in _context.Jogadores
                                 where j.Id == jogadorId
                                 select new ObterJogadorResponse
                                 {
                                     Id = j.Id,
                                     Nome = j.Nome,
                                     Email = j.Email,
                                     telefone = j.Telefone,
                                     Codinome = j.Codinome,
                                     Grupo = j.Grupo
                                 }).FirstOrDefaultAsync();
            return jogador;
        }
    }
}
