using Microsoft.OpenApi.Models;
using Assesment.Application;
using Assesment.Infrastructure;
using Assesment.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// builder.Services.AddScoped<IUserService, UserService>();

// Services Registration
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddSwaggerGen(
    c =>  {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    }
);


// var configuration = new ConfigurationBuilder()
//         .SetBasePath(Directory.GetCurrentDirectory())
//         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//         .Build();
// var jwtSettings = new JwtSettings();
// configuration.GetSection(JwtSettings.SectionName).Bind(jwtSettings);
// jwtSettings.Configuration = configuration;



// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {

    

//     options.TokenValidationParameters = new TokenValidationParameters
    // {
    //     ValidateIssuer = true,
    //     ValidateAudience = true,
    //     ValidateIssuerSigningKey = true,
    //     ValidIssuer = jwtSettings.Issuer,
    //     ValidAudience = jwtSettings.Audience,
    //     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    // };
// });

// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
// });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
