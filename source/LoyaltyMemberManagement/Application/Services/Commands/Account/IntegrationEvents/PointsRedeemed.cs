using Application.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Services.Commands.Account.IntegrationEvents
{
    public class PointsRedeemed : IRequest
    {
        public long AccountId { get; set; }
        public decimal Point { get;  set; }
        public class PointsRedeemedHandler : IRequestHandler<PointsRedeemed>
        {
            private readonly IEventBusService _eventBus;
            public PointsRedeemedHandler(IEventBusService eventBus)
            {
                _eventBus = eventBus;
            }
            public async Task<Unit> Handle(PointsRedeemed notification, CancellationToken cancellationToken)
            {
                //Sample usage to send redeemed point to the  event bus 
                //string data = JsonConvert.SerializeObject(notification, Formatting.Indented);
                //await _eventBus.SendEventBusAsync(data, "pointsRedeemed");
                return Unit.Value;
            }
        }
    }
}
