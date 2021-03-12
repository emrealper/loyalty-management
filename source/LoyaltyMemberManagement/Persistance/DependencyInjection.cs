using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Persistance.Repositories;
using Persistance.DataAccess;
namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MemberManagementDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("MemberManagementDatabase")));
            services.AddScoped<IMemberManagementDbContext>(provider => provider.GetService<MemberManagementDbContext>());
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
