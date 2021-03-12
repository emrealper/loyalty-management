using Application.Interfaces;
using Application.Services.Commands.Account.IntegrationEvents;
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
        private readonly IMediator _mediator;
        public RedeemPointCommandHandler(IMemberManagementDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<long> Handle(RedeemPointCommand request, CancellationToken cancellationToken)
        {
            var memberAccount = await _context.MemberAccounts.FindAsync(request.MemberAccountId);
            memberAccount.RedeemPointFromAccount(request.Point);
            _context.MemberAccounts.Update(memberAccount);
            await _context.SaveChangesAsync(cancellationToken);
            //publish to integration event
            await _mediator.Send(new PointsRedeemed
            {
                AccountId = memberAccount.Id,
                Point = request.Point
            }, cancellationToken);
            return memberAccount.Id;
        }
    }
}
