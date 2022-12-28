using Application.Requests;
using Domain.Command;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class AddVingadorHandler : IRequestHandler<AddVingadorRequest, GenericRequestResult>
    {
        private readonly IVingadorRepository _repository;

        public AddVingadorHandler(IVingadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenericRequestResult> Handle(AddVingadorRequest request, CancellationToken cancellationToken)
        {
            var vingador = new Vingadores.Vingador(request.codinomeVingador);

            await _repository.SalvarAsync(vingador);

            return new GenericRequestResult(true, "Vingador Cadastrado", vingador);
        }
    }
}
