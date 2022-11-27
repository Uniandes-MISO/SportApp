using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportApp.Api.Controllers;
using SportApp.Api.Extensions;
using SportApp.Api.Models;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;
using System;
using System.Configuration;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class AccountControllerTest
{
    private WebApplicationBuilder builder;

    [SetUp]
    public void Init()
    {
        //var builder = WebApplication.CreateBuilder();

        //var mapperConfig = new MapperConfiguration(map =>
        //{
        //    map.AddProfile<SportActivityMappingProfile>();
        //    map.AddProfile<MembershipPlanMappingProfile>();
        //    map.AddProfile<RouteMappingProfile>();
        //    map.AddProfile<EventMappingProfile>();
        //    map.AddProfile<ServiceMappingProfile>();
        //    map.AddProfile<ActivityMappingProfile>();
        //    map.AddProfile<TrainingMappingProfile>();
        //    map.AddProfile<UserTrainingMappingProfile>();
        //    map.AddProfile<VirtualSessionMappingProfile>();
        //});
        //var serviceCollection = new ServiceCollection();
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile(
        //         path: "appsettings.json",
        //         optional: false,
        //reloadOnChange: true)
        //   .Build();
        //serviceCollection.AddSingleton<IConfiguration>(configuration);
        //serviceCollection.AddTransient<AccountController, AccountController>();
        //serviceCollection.AddSingleton(mapperConfig.CreateMapper());

        //ServiceProvider = serviceCollection.BuildServiceProvider();

        //serviceCollection.RegisterDependencies();
        //serviceCollection.ConfigureMapping();

        //serviceCollection.AddAppDbContext(configuration);

        //serviceCollection.AddAuthentication();
        //serviceCollection.ConfigureIdentity();
        //serviceCollection.ConfigureJWT(configuration);

        builder = WebApplication.CreateBuilder();

        //LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        //LoggerManager logger = new LoggerManager();

        // Add services to the container.
        builder.Services.RegisterDependencies();
        builder.Services.AddTransient<AccountController, AccountController>();

        builder.Services.ConfigureMapping();
        //builder.Services.ConfigureLoggerService();

        // register application DB context
        //AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        //builder.Services.AddAppDbContext(builder.Configuration);
        builder.Services.AddDbContext<IAppDbContext, AppDbContext>(
                opt => opt.UseInMemoryDatabase(databaseName: "SportApp"));

        /*
         services.AddDbContext<IAppDbContext, AppDbContext>(
                opt => opt.UseNpgsql(postgresConfig.ConnectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(name)));

         * var options = new DbContextOptionsBuilder<T>()
       .UseInMemoryDatabase(databaseName: nameDatabase)
       .Options;
        */
        //builder.Services.AddAuthentication();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureJWT(builder.Configuration);

        //builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();

        //builder.Services.ConfigureSwagger();
        //builder.Services.AddSwaggerGen();

        ServiceProvider = builder.Services.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }

    [Test]
    public void Register()
    {
        var model = new RegisterModel
        {
            Email = "test@test.com",
            FirstName = "Firs",
            LastName = "Last",
            Password = "123*1#$1As"
        };

        var contro = ServiceProvider.GetService<AccountController>();
        var result = contro.Register(model);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Login()
    {
        var model = new RegisterModel
        {
            Email = "test@test.com",
            FirstName = "Firs",
            LastName = "Last",
            Password = "123*1#$1As"
        };

        var contro = ServiceProvider.GetService<AccountController>();
        _ = contro.Register(model);

        var dto = new LoginModel
        {
            Password = "123*1#$1As",
            Username = "test@test.com"
        };

        var result = contro.Login(dto);

        Assert.That(result, Is.Not.Null);
    }
}