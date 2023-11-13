using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Assesment.Application.Contracts.Infrastructure;
using Assesment.Infrastructure.DateTimeService;
using Assesment.Infrastructure.JWT;
using Assesment.Infrastructure.PasswordService;


namespace Assesment.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.RegisterAuthenticationServices(configuration);
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

   public static IServiceCollection RegisterAuthenticationServices(
    this IServiceCollection services,
    IConfiguration configuration
)
{
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    services.AddScoped<IJwtGenerator, JwtGenerator>();

    var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
    if (jwtSettings != null)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
    }

    return services;
}
}
