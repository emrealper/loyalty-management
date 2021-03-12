using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Commands.Member.Validator
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(t => t.Name).NotNull().NotEmpty();
            RuleFor(t => t.Address).NotNull().NotEmpty();
        }
    }
}
