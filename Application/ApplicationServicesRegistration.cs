using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Assesment.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServicesRegistration).GetTypeInfo().Assembly());
            services.AddAutoMapper(typeof(ApplicationServicesRegistration).GetTypeInfo().Assembly);

            return services;
        }
    }
}