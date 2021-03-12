using Application.Interfaces;
using Application.Interfaces.Common;
using Infrastructure.EventBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            //By using AddSingleton we create single instance of the EventBusService
            //When we first requested and reuse the same instance where it needed
            services.AddSingleton<IEventBusService, EventBusService>();
            return services;
        }
    }
}
