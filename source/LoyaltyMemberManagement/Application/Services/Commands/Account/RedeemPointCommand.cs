using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Commands.Account
{
   public class RedeemPointCommand : IRequest<long>
    {


        public long MemberAccountId { get; set; }

        public Decimal Point { get; set; }



    



    }
}
