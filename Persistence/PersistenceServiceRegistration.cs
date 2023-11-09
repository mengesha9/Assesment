using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Assesment.Application.Contracts.Persistence;
using Assesment.Persistence;
using Assesment.Persistence.Repositoties;

namespace SocialSync.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AssesmentApiDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRespositoty<>));
        services.AddScoped<IProductRepository, ProductRespository>();
        services.AddScoped<ICatagoryRepository, CatagoryRepository>();
        return services;
    }
}
