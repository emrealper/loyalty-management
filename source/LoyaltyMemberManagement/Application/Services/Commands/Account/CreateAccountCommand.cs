using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Commands.Account
{
   public class CreateAccountCommand :IRequest<long>
    {
        public long MemberId { get; set; }
        public MemberNewAccountDto MemberAccount { get; set; }
         public class MemberNewAccountDto
        {
            public string Name { get; set; }
        }
    }
}
