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
    public class AccountCreated : IRequest
    {


        public long Id { get; set; }
        public string Name { get;  set; }




        public class AccountCreatedHandler : IRequestHandler<AccountCreated>
        {

            private readonly IEventBusService _eventBus;


            public AccountCreatedHandler(IEventBusService eventBus)
            {

                _eventBus = eventBus;
            }

            public async Task<Unit> Handle(AccountCreated notification, CancellationToken cancellationToken)
            {



                //Sample usage to send created account to the  event bus 
                //string data = JsonConvert.SerializeObject(notification, Formatting.Indented);
                //await _eventBus.SendEventBusAsync(data, "orderPaid");

                return Unit.Value;

            }
        }


    }
}
