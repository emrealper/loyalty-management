using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services.Commands.Member.IntegrationEvents
{
    public class MemberCreated : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public class MemberCreatedHandler : IRequestHandler<MemberCreated>
        {
            private readonly IEventBusService _eventBus;
            public MemberCreatedHandler(IEventBusService eventBus)
            {
                _eventBus = eventBus;
            }
            public async Task<Unit> Handle(MemberCreated notification, CancellationToken cancellationToken)
            {
                //Sample usage to send created member to the  event bus 
                //string data = JsonConvert.SerializeObject(notification, Formatting.Indented);
                //await _eventBus.SendEventBusAsync(data, "memberCreated");
                return Unit.Value;
            }
        }
    }
}
