using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
namespace Application.Services.Commands.Bulk
{
   public class CreateBulkMemberCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<AccountDto> Accounts { get; set; }
        public class AccountDto
        {
            public decimal Balance { get; set; }
            public string Status { get; set; }
            public string Name { get; set; }
        }
    }
}
