using Application.Requests;
using Domain.Command;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class ExcluirJogadorHandler : IRequestHandler<ExcluirJogadorRequest, GenericRequestResult>
    {
        private readonly IJogadorRepository _jogadorRepository;

        public ExcluirJogadorHandler(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public async Task<GenericRequestResult> Handle(ExcluirJogadorRequest request, CancellationToken cancellationToken)
        {
            await _jogadorRepository.ExcluirJogadorAsync(request.jogadorId);

            return new GenericRequestResult(true, "Jogador excluido", null);
        }
    }
}
