using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.Account
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, long>
    {
        private readonly IMemberManagementDbContext _context;


        public CreateAccountCommandHandler(IMemberManagementDbContext context)
        {
            _context = context;


        }

        public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            var member = await _context.Members.FindAsync(request.MemberId);

            member.AddANewEmptyMemberAccount(request.MemberAccount.Name);

            _context.Members.Update(member);
            await _context.SaveChangesAsync(cancellationToken);

            return member.Id;

        }
    }
}
