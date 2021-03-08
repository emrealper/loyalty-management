using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.Account
{
    public class RedeemPointCommandHandler : IRequestHandler<RedeemPointCommand, long>
    {
        private readonly IMemberManagementDbContext _context;


        public RedeemPointCommandHandler(IMemberManagementDbContext context)
        {
            _context = context;


        }

        public async Task<long> Handle(RedeemPointCommand request, CancellationToken cancellationToken)
        {

         
            var memberAccount = await _context.MemberAccounts.FindAsync(request.MemberAccountId);
            memberAccount.RedeemPointFromAccount(request.Point);

            _context.MemberAccounts.Update(memberAccount);
            await _context.SaveChangesAsync(cancellationToken);

            return memberAccount.Id;

        }
    }
}
