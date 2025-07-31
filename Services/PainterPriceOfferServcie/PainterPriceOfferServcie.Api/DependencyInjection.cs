using BuildingBlocks.Behavior;
using BuildingBlocks.Handlers;
using BuildingBlocks.Persistence.Mongo;
using FluentValidation;
using Mapster;
using MapsterMapper;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.CreateMaterialUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Infrastructure.Persistence.Repositories;
using System.Reflection;

namespace PainterPriceOfferServcie.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBasicServices(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            //var redisConnection = configuration.GetValue<string>("Redis:Connection");
            //var postgresConnection = configuration.GetConnectionString("IdentityDatabase");

            //Add Redis connection multiplexer
            //services.AddSingleton<IConnectionMultiplexer>(sp =>
            //{
            //    return ConnectionMultiplexer.Connect(redisConnection!);
            //});

            //Add MediatR services
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(executingAssembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));// Kell rá NUGET csomag
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));// Kell rá NUGET csomag
            });

            //Add Mapper services
            services.AddSingleton<IMapper, Mapper>();

            //Add exception handler services
            services.AddExceptionHandler<CustomExceptionHandler>();//Kell rá NUGET csomag minden exceptiont és handlert ki kell vezetni a BuildingBlocksból
            services.AddProblemDetails();

            services.AddValidatorsFromAssemblyContaining<CreateMaterialUnitValidator>();
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            TypeAdapterConfig.GlobalSettings.Scan(executingAssembly);

            //Add Health checks
            //services.AddDefaultHealthChecks(new Dictionary<string, string>
            //{
            //    { "postgres", postgresConnection! },
            //    { "redis", redisConnection! }
            //});
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Add swagger services with JWT Authentication
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(setup =>
            {
                setup.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                setup.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddCorsOrigin(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // Engedélyezett frontend domain
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .WithExposedHeaders("Referrer-Policy"); // Fejlécek engedélyezése
                });
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMaterialUnitRepository, MaterialUnitRepository>();
            services.AddScoped<IWorkUnitRepository, WorkUnitRepository>();
            services.AddScoped<IPriceOfferRepository, PriceOfferRepository>();
            services.AddScoped<IBaseSettingRepository, BaseSettingRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        public static WebApplication UseSwaggerServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
