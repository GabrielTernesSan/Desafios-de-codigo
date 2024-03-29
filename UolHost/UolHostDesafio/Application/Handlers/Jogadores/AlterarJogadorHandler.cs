﻿using Application.Requests.Jogador;
using Domain.Command;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Jogadores
{
    public class AlterarJogadorHandler : IRequestHandler<AlterarJogadorRequest, GenericRequestResult>
    {

        private readonly IJogadorRepository _jogadorRepository;
        private readonly IJogadorQuery _jogadorQuery;

        public AlterarJogadorHandler(IJogadorRepository jogadorRepository, IJogadorQuery jogadorQuery)
        {
            _jogadorRepository = jogadorRepository;
            _jogadorQuery = jogadorQuery;
        }

        public async Task<GenericRequestResult> Handle(AlterarJogadorRequest request, CancellationToken cancellationToken)
        {
            var jogador = await _jogadorQuery.ObterJogadorIdAsync(request.jogadorId);

            if (jogador != null)
            {
                jogador.Nome = request.Nome;
                jogador.Email = request.Email;
                jogador.telefone = request.Telefone;
                jogador.Codinome = jogador.Codinome;
                jogador.Grupo = jogador.Grupo;

                await _jogadorRepository.AtualizarJogadorAsync(new Jogador(jogador.Id, jogador.Nome, jogador.Email, jogador.telefone, jogador.Codinome, jogador.Grupo));
                return new GenericRequestResult(true, "Jogador atualizado", jogador);
            }
            else
            {
                return new GenericRequestResult(false, "Jogador não encontrado", null);
            }
        }
    }
}
