using Application.Interfaces;
using Application.Services.Commands.Bulk;
using Domain.AggregatesModel.MemberAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services.Commands
{
    public class CreateBulkMembersCommandHandler : IRequestHandler<CreateBulkMemberCommand, bool>
    {
        private readonly IMemberManagementDbContext _context;
        public CreateBulkMembersCommandHandler(IMemberManagementDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateBulkMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Domain.AggregatesModel.MemberAggregate.Member(request.Name, request.Address);
            foreach(var accountItem in request.Accounts)
             {
                    member.AddMemberAccount(accountItem.Balance,accountItem.Status,accountItem.Name);
             }
            _context.Members.Add(member);
            await _context.SaveChangesAsync(cancellationToken);
             return true;
        }
    }
}
