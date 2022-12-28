using Application.Requests;
using Domain.Command;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
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

            foreach (var jogador in jogadoresExistentes)
            {
                if (request.Nome.Equals(jogador.Nome) || request.Email.Equals(jogador.Email))
                {
                    return new GenericRequestResult(false, "Jogador já cadastrado", null);
                }
            }

            var jogadorCadastrado = new Jogador(request.Nome, request.Email, request.Telefone, request.Codinome, request.Grupo);

            await _repository.SalvarAsync(jogadorCadastrado);

            return new GenericRequestResult(true, "Jogador Cadastrado", jogadorCadastrado);
        }
    }
}
