using Application.Interfaces;
using Application.Services.Commands.Account.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services.Commands.Account
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, long>
    {
        private readonly IMemberManagementDbContext _context;
        private readonly IMediator _mediator;
        public CreateAccountCommandHandler(IMemberManagementDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var member = await _context.Members.FindAsync(request.MemberId);
            member.AddANewEmptyMemberAccount(request.MemberAccount.Name);
            _context.Members.Update(member);
            await _context.SaveChangesAsync(cancellationToken);
            //publish to integration event
            await _mediator.Send(new AccountCreated
            {
                Id = member.MemberAccounts.ElementAt(0).Id,
                Name = request.MemberAccount.Name
            }, cancellationToken);
            return member.Id;
        }
    }
}
