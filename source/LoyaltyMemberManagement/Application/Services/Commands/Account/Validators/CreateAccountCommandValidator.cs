using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Commands.Account.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
 
            RuleFor(t => t.MemberId).NotNull().GreaterThan(0);

            RuleFor(t => t.MemberAccount).NotNull();

            RuleFor(t => t.MemberAccount.Name).NotEmpty().When(t => t.MemberAccount != null);

        }
    }
}
