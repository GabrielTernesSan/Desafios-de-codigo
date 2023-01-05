using Domain.Command;
using Domain.Enums;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests.Jogador
{
    public class AlterarJogadorRequest : IRequest<GenericRequestResult>
    {
        [JsonIgnore]
        public int jogadorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class AlterarJogadorRequestValidator : AbstractValidator<AlterarJogadorRequest>
    {
        public AlterarJogadorRequestValidator()
        {
            RuleFor(r => r.Nome).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
        }
    }
}
