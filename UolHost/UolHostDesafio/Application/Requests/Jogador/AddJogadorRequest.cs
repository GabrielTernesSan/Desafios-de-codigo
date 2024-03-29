﻿using Domain.Command;
using Domain.Enums;
using MediatR;
using FluentValidation;

namespace Application.Requests.Jogador
{
    public class AddJogadorRequest : IRequest<GenericRequestResult>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EGrupo Grupo { get; set; }
    }

    public class AddJogadorRequestValidator : AbstractValidator<AddJogadorRequest>
    {
        public AddJogadorRequestValidator()
        {
            RuleFor(r => r.Nome).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Telefone)
                .Matches("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$");
        }
    }
}
