using Application.Interfaces;
using Application.Services.Commands.Member.IntegrationEvents;
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
        private readonly IMediator _mediator;


        public CreateMemberCommandHandler(IMemberManagementDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;


        }

        public async Task<long> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {

            var member = new Domain.AggregatesModel.MemberAggregate.Member(request.Name,request.Address);

            _context.Members.Add(member);
            await _context.SaveChangesAsync(cancellationToken);

            //publish to integration event
            await _mediator.Send(new MemberCreated
            {

                Id = member.Id,
                Name = request.Name,
                Address= request.Address

            }, cancellationToken);

            return member.Id;

        }
    }
}
