using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;
using System.Text;

namespace SportApp.Api.Extensions;

public static class ServiceExtension
{
    //public static void ConfigureLoggerService(this IServiceCollection services) =>
    //    services.AddScoped<ILoggerManager, LoggerManager>();

    public static void ConfigureMapping(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<SportActivityMappingProfile>();
            map.AddProfile<MembershipPlanMappingProfile>();
            map.AddProfile<RouteMappingProfile>();
            map.AddProfile<EventMappingProfile>();
            map.AddProfile<ServiceMappingProfile>();
            map.AddProfile<ActivityMappingProfile>();
            map.AddProfile<TrainingMappingProfile>();
            map.AddProfile<UserTrainingMappingProfile>();
            map.AddProfile<VirtualSessionMappingProfile>();
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration.GetSection("JWT");
        var secretKey = jwtConfig["Secret"];
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,

                ValidIssuer = jwtConfig["ValidIssuer"],
                ValidAudience = jwtConfig["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "V1",
                Title = "WebAPI",
                Description = "SportApp WebAPI",
                Contact = new OpenApiContact
                {
                    Name = "SportApp"
                },
            });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISportActivityService, SportActivityService>();
        services.AddScoped<IMembershipPlanService, MembershipPlanService>();
        services.AddScoped<IRouteService, RouteService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ITrainingService, TrainingService>();
        services.AddScoped<IUserTrainingService, UserTrainingService>();
        services.AddScoped<IVirtualSessionService, VirtualSessionService>();
        services.AddScoped<IEatingRoutineService, EatingRoutineService>();
        services.AddScoped<IEatingRoutineBusinessService, EatingRoutineBusinessService>();
    }
}