using Application.Interfaces;
using Domain.AggregatesModel.MemberAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, long>
    {
        private readonly IMemberManagementDbContext _context;
  

        public CreateMemberCommandHandler(IMemberManagementDbContext context)
        {
            _context = context;


        }

        public async Task<long> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {

            var member = new Member(request.Name,request.Address);

            _context.Members.Add(member);
            await _context.SaveChangesAsync(cancellationToken);

            return member.Id;

        }
    }
}
