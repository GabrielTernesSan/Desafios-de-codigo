using Domain.Queries;
using Domain.Queries.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class JogadorQuery : IJogadorQuery
    {

        private readonly Context _context;
        private readonly ContextMemory _contextMemory;

        public JogadorQuery(Context context, ContextMemory contextMemory)
        {
            _context = context;
            _contextMemory = contextMemory;
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

        public async Task<IEnumerable<string>> VerificarLiga()
        {
            var membrosLigaCadastrados = await _context.Jogadores.Select(j => j.Codinome).ToListAsync();

            var membrosLigaMemoria = await _contextMemory.LigaDaJustica.Select(s => s.codinome).ToListAsync();
            
            var membrosLigaDisponiveis = membrosLigaMemoria.Except(membrosLigaCadastrados);

            return membrosLigaDisponiveis;
        }

        public async Task<IEnumerable<string>> VerificarVingadores()
        {
            var vingadoresCadastrados = await _context.Jogadores.Select(j => j.Codinome).ToListAsync();

            var vingadoresMemoria = await _contextMemory.Vingadores.Select(s => s.codinome).ToListAsync();
            
            var vingadoresDisponiveis = vingadoresMemoria.Except(vingadoresCadastrados);

            return vingadoresDisponiveis;
        }
    }
}
