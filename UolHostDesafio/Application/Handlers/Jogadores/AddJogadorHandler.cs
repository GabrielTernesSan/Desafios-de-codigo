using Application.Requests.Jogador;
using Domain.Command;
using Domain.Entities;
using Domain.Enums;
using Domain.Queries;
using Domain.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Handlers.Jogadores
{
    public class AddJogadorHandler : IRequestHandler<AddJogadorRequest, GenericRequestResult>
    {

        private readonly IJogadorRepository _repository;
        private readonly IJogadorQuery _query;

        public AddJogadorHandler(IJogadorRepository repository, IJogadorQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public async Task<GenericRequestResult> Handle(AddJogadorRequest request, CancellationToken cancellationToken)
        {
            var jogadoresExistentes = await _query.ObterJogadoresAsync();
            var vingadoresDisponiveis = await _query.VerificarVingadores();
            var LigaDisponiveis = await _query.VerificarLiga();
            var random = new Random();

            foreach (var jogador in jogadoresExistentes)
            {
                if (request.Nome.Equals(jogador.Nome) || request.Email.Equals(jogador.Email))
                {
                    return new GenericRequestResult(false, "Jogador já cadastrado", null);
                }
            }

            if (request.Grupo.Equals(EGrupo.VINGADORES) && !vingadoresDisponiveis.IsNullOrEmpty())
            {
                var index = random.Next(vingadoresDisponiveis.Count());

                var jogadorCadastrado = new Jogador(request.Nome, request.Email, request.Telefone, request.Grupo);

                jogadorCadastrado.Codinome = vingadoresDisponiveis.ElementAt(index);

                await _repository.SalvarAsync(jogadorCadastrado);

                return new GenericRequestResult(true, "Jogador Cadastrado", jogadorCadastrado);
            }
            else if (request.Grupo.Equals(EGrupo.LIGA) && !LigaDisponiveis.IsNullOrEmpty())
            {
                var index = random.Next(LigaDisponiveis.Count());

                var jogadorCadastrado = new Jogador(request.Nome, request.Email, request.Telefone, request.Grupo);

                jogadorCadastrado.Codinome = LigaDisponiveis.ElementAt(index);

                await _repository.SalvarAsync(jogadorCadastrado);

                return new GenericRequestResult(true, "Jogador Cadastrado", jogadorCadastrado);
            }
            else
            {
                return new GenericRequestResult(false, "Codinomes indiponíveis", null);
            }
        }
    }
}
