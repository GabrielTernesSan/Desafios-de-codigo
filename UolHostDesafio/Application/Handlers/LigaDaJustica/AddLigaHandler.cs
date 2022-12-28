using Application.Requests.LigaDaJustica;
using Domain.Command;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.LigaDaJustica
{
    public class AddLigaHandler : IRequestHandler<AddLigaRequest, GenericRequestResult>
    {

        private readonly ILigaRespository _repository;

        public AddLigaHandler(ILigaRespository repository)
        {
            _repository = repository;
        }

        public async Task<GenericRequestResult> Handle(AddLigaRequest request, CancellationToken cancellationToken)
        {
            var liga = new Liga(request.codinomeLiga);

            await _repository.SalvarAsync(liga.Codinome);

            return new GenericRequestResult(true, "Liga da justiça Cadastrado", liga);
        }
    }
}
