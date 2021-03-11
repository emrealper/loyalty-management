using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Commands.Bulk.Validators
{
    public class CreateBulkMemberCommandValidator : AbstractValidator<CreateBulkMemberCommand>
    {
        public CreateBulkMemberCommandValidator()
        {

            RuleFor(t => t.Name).NotNull().NotEmpty();
            RuleFor(t => t.Address).NotNull().NotEmpty();
            RuleFor(t => t.Accounts).NotNull();


        }
    }
}
