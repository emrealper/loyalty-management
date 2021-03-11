using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Commands.Account.Validators
{
    public class RedeemPointCommandValidator : AbstractValidator<RedeemPointCommand>
    {
        public RedeemPointCommandValidator()
        {

            RuleFor(t => t.MemberAccountId).NotNull().GreaterThan(0);
            RuleFor(t => t.Point).NotNull().GreaterThanOrEqualTo(0);


        }
    }
}
