using Domain.Command;
using FluentValidation;
using MediatR;

namespace Application.Requests
{
    public class AddVingadorRequest : IRequest<GenericRequestResult>
    {
        public string codinomeVingador { get; set; }
    }

    public class AddVingadorRequestValidator : AbstractValidator<AddVingadorRequest>
    {
        public AddVingadorRequestValidator()
        {
            RuleFor(r => r.codinomeVingador).NotEmpty();
        }
    }
}
