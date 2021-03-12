using Application.Services.Commands.Account;
using Application.Services.Commands.Account.Validators;
using Domain.AggregatesModel.MemberAggregate;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Application.Services.Commands.Account.CreateAccountCommand;
namespace Member.UnitTests.ApplicationTests.Commands
{
    public class AccountCommandValidatorTests
    {
        [Fact]
        public void IsValid_ShouldBeFalse_WhenCreateAccountCommandIsNotValid()
        {
            var commandWithNullAccount = new CreateAccountCommand
            {
                MemberId = 0,
                MemberAccount = null
            };
            var memberNewAccountDto = new MemberNewAccountDto();
            memberNewAccountDto.Name = "";
            var commandWithEmptyAccountName = new CreateAccountCommand
            {
                MemberId = 1,
                MemberAccount = memberNewAccountDto
            };
            var validator = new CreateAccountCommandValidator();
            var result = validator.Validate(commandWithNullAccount);
            var resultForEmptyAccountName= validator.Validate(commandWithEmptyAccountName);
            result.IsValid.ShouldBe(false);
            resultForEmptyAccountName.IsValid.ShouldBe(false);
        }
        [Fact]
        public void IsValid_ShouldBeFalse_WhenCollectPointCommandIsNotValid()
        {
            var command = new CollectPointCommand
            {
                MemberAccountId = 0,
                Point = -1
            };
            var validator = new CollectPointCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }
        [Fact]
        public void IsValid_ShouldBeFalse_WhenRedeemPointCommandIsNotValid()
        {
            var command = new RedeemPointCommand
            {
                MemberAccountId = 0,
                Point = -1
            };
            var validator = new RedeemPointCommandValidator();
            var result = validator.Validate(command);
            result.IsValid.ShouldBe(false);
        }
    }
}
