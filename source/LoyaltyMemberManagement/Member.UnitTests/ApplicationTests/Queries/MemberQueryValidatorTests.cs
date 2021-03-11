using Application.Services.Queries.Member;
using Application.Services.Queries.Member.Validators;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Member.UnitTests.ApplicationTests.Queries
{
  public class MemberQueryValidatorTests
    {

        [Fact]
        public void IsValid_ShouldBeFalse_WhenMemberMinPointQueryIsNotValid()
        {
            var query = new ListWithMinPointAndAccountStatusQuery
            {
                MinPoint = 100,
                AccountStatus = string.Empty
            };



            var validator = new ListWithMinPointAndAccountStatusQueryValidator();

            var result = validator.Validate(query);


            result.IsValid.ShouldBe(false);

        }
    }
}
