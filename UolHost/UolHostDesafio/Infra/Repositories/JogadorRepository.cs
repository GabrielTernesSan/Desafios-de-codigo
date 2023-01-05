using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly Context _context;

        public JogadorRepository(Context context)
        {
            _context = context;
        }

        public async Task SalvarAsync(Jogador jogador)
        {
            var cadastraJogador = new Tables.Jogador
            {
                Nome = jogador.Nome,
                Email = jogador.Email,
                Telefone = jogador.Telefone,
                Codinome = jogador.Codinome,
                Grupo = jogador.Grupo
            };

            await _context.Jogadores.AddAsync(cadastraJogador);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarJogadorAsync(Jogador JogadorAtualizado)
        {
            var jogador = await _context.Jogadores
               .Where(w => w.Id == JogadorAtualizado.Id)
               .FirstOrDefaultAsync();

            if (jogador != null)
            {
                jogador.Nome = JogadorAtualizado.Nome;
                jogador.Email = JogadorAtualizado.Email;
                jogador.Telefone = JogadorAtualizado.Telefone;
                jogador.Grupo = JogadorAtualizado.Grupo;

                _context.Entry(jogador).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ExcluirJogadorAsync(int jogadorId)
        {
            var jogador = await _context.Jogadores
               .Where(w => w.Id == jogadorId)
               .FirstOrDefaultAsync();

            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogador> ObterJogadorAsync(int jogadorId)
        {
            var jogador = await _context.Jogadores
            .Where(j => j.Id == jogadorId).Select(s => new Jogador
            (
                s.Nome,
                s.Email,
                s.Telefone,
                s.Codinome,
                s.Grupo
            )).FirstOrDefaultAsync();

            return jogador;
        }   
    }
}
