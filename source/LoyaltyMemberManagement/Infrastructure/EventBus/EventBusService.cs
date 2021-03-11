using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus
{
    public class EventBusService : IEventBusService
    {

        public async Task SendEventBusAsync(string message, string topicName)
        {

            return;
        }
    }

}
