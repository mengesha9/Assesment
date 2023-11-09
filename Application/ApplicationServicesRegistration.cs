using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Assesment.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplication(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}