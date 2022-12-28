using Domain.Command;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests
{
    public class ExcluirJogadorRequest : IRequest<GenericRequestResult>
    {
        [JsonIgnore]
        public int jogadorId { get; set; }
    }
    public class ExcluirJogadorRequestValidator : AbstractValidator<ExcluirJogadorRequest>
    {
        public ExcluirJogadorRequestValidator()
        {
            RuleFor(r => r.jogadorId).NotEmpty();
        }
    }
}
