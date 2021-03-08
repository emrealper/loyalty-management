using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.Account
{
    public class CollectPointCommandHandler : IRequestHandler<CollectPointCommand, long>
    {
        private readonly IMemberManagementDbContext _context;


        public CollectPointCommandHandler(IMemberManagementDbContext context)
        {
            _context = context;


        }

        public async Task<long> Handle(CollectPointCommand request, CancellationToken cancellationToken)
        {

         
            var memberAccount = await _context.MemberAccounts.FindAsync(request.MemberAccountId);
            memberAccount.CollectPointToAccount(request.Point);

            _context.MemberAccounts.Update(memberAccount);
            await _context.SaveChangesAsync(cancellationToken);

            return memberAccount.Id;

        }
    }
}
