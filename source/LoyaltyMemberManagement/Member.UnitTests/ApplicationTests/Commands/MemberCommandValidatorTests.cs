using Application.Services.Commands;
using Application.Services.Commands.Member.Validator;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Member.UnitTests.ApplicationTests.Commands
{
   public class MemberCommandValidatorTests
    {
        [Fact]
        public void IsValid_ShouldBeFalse_WhenCreateMemberCommandIsNotValid()
        {
            var command = new CreateMemberCommand
            {
                Name = string.Empty,
                Address = string.Empty
            };
            var validator = new CreateMemberCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }
    }
}
