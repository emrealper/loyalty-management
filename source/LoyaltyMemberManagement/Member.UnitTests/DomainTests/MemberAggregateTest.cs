using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Domain.AggregatesModel.MemberAggregate;
using Domain.Exceptions;
namespace Member.UnitTests.DomainTests
{
   public class MemberAggregateTest
    {
        public MemberAggregateTest()
        { 
        }
        [Fact]
        public void Create_Member_Success()
        {
            //Arrange    
            var name = "Emre Alper";
            var address = "Landsberger Straße 117";
            //Act 
            var fakeMember = new Domain.AggregatesModel.MemberAggregate.Member(name,address);
            //Assert
            Assert.NotNull(fakeMember);
        }
        [Fact]
        public void Add_MemberAccount_Success()
        {
            //Arrange    
            var membername = "Emre Alper";
            var address = "Landsberger Straße 117";
            var balance = 100;
            var status = "ACTIVE";
            var name = "Lufthansa";
            //Act 
            var fakeMember = new Domain.AggregatesModel.MemberAggregate.Member(membername, address);
            fakeMember.AddMemberAccount(balance,status,name);
            //Assert
            Assert.NotNull(fakeMember.MemberAccounts);
        }
        [Fact]
        public void Add_Empty_MemberAccount_Success()
        {
            //Arrange    
            var membername = "Emre Alper";
            var address = "Landsberger Straße 117";
            var name = "Lufthansa";
            //Act 
            var fakeMember = new Domain.AggregatesModel.MemberAggregate.Member(membername, address);
            fakeMember.AddANewEmptyMemberAccount(name);
            //Assert
            Assert.NotNull(fakeMember.MemberAccounts);
        }
        [Fact]
        public void SHOULD_THROW_ERROR_WHEN_REDEEMED_FROM_EMPTY_ACCOUNT()
        {
            //Arrange    
            var name = "Lufthansa";
            var status = "ACTIVE";
            var balance = 0;
            //Act 
            var fakeMemberAccount = new MemberAccount(balance, status, name);
            //Assert
            Assert.Throws<MemberDomainException>(() => fakeMemberAccount.RedeemPointFromAccount(100));
        }
        [Fact]
        public void SHOULD_THROW_ERROR_WHEN_REDEEMED_FROM_INACTIVE_ACCOUNT()
        {
            //Arrange    
            var name = "Lufthansa";
            var status = "INACTIVE";
            var balance = 100;
            //Act 
            var fakeMemberAccount = new MemberAccount(balance, status, name);
            //Assert
            Assert.Throws<MemberDomainException>(() => fakeMemberAccount.RedeemPointFromAccount(100));
        }
        [Fact]
        public void SHOULD_THROW_ERROR_WHEN_REDEEMED_FROM_ACCOUNT_BALANCE_NOT_ENOUGH()
        {
            //Arrange    
            var name = "Lufthansa";
            var status = "ACTIVE";
            var balance = 100;
            //Act 
            var fakeMemberAccount = new MemberAccount(balance, status, name);
            //Assert
            Assert.Throws<MemberDomainException>(() => fakeMemberAccount.RedeemPointFromAccount(200));
        }
    }
}
