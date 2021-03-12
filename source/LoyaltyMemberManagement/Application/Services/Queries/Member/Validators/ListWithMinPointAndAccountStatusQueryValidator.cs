using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Queries.Member.Validators
{
    public class ListWithMinPointAndAccountStatusQueryValidator : AbstractValidator<ListWithMinPointAndAccountStatusQuery>
    {
        public ListWithMinPointAndAccountStatusQueryValidator()
        {
            RuleFor(t => t.MinPoint).NotNull();
            RuleFor(t => t.AccountStatus).NotEmpty();
        }
    }
}
