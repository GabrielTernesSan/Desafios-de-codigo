using Domain.Command;
using FluentValidation;
using MediatR;

namespace Application.Requests.LigaDaJustica
{
    public class AddLigaRequest : IRequest<GenericRequestResult>
    {
        public string codinomeLiga { get; set; }
    }

    public class AddLigaRequestValidator : AbstractValidator<AddLigaRequest>
    {
        public AddLigaRequestValidator()
        {
            RuleFor(r => r.codinomeLiga).NotEmpty();
        }
    }
}
