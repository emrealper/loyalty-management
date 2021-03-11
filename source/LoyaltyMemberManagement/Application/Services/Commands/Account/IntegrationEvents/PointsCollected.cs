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
    public class PointsCollected :IRequest
    {


        public long AccountId { get; set; }
        public decimal Point { get;  set; }




        public class PointsCollectedHandler : IRequestHandler<PointsCollected>
        {

            private readonly IEventBusService _eventBus;


            public PointsCollectedHandler(IEventBusService eventBus)
            {

                _eventBus = eventBus;
            }

            public async Task<Unit> Handle(PointsCollected notification, CancellationToken cancellationToken)
            {



                //Sample usage to send collected point to the  event bus 
                //string data = JsonConvert.SerializeObject(notification, Formatting.Indented);
                //await _eventBus.SendEventBusAsync(data, "pointsCollected");


                return Unit.Value;

            }
        }


    }
}
