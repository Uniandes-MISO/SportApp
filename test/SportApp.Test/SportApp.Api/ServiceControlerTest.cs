using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Api.Controllers;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class ServiceControlerTest
{
    private MapperConfiguration mapperConfig;

    [SetUp]
    public void Init()
    {
        mapperConfig = new MapperConfiguration(map =>
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
    }

    [Test]
    public void CreateService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        var service1 = new Service
        {
            Id = id,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();

        var news = new ServiceDto
        {
            Id = 123,
            Description = "",
            Email = "test@test.com",
            Name = "Test",
            Phone = "111",
            SportType = "Cycling",
            Type = "Sportsman",
            UserId = userId,
            Website = "ww.google.com"
        };

        var controler = new ServiceController(mapperConfig.CreateMapper(), service);
        var result = controler.Create(news, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void UpdateService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        var service1 = new Service
        {
            Id = id,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);

        var servi1 = new Service
        {
            Id = 1234,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(servi1);
        context.SaveChanges();

        var news = new ServiceDto
        {
            Id = 1234,
            Description = "",
            Email = "test@test.com",
            Name = "Test",
            Phone = "111",
            SportType = "Cycling",
            Type = "Sportsman",
            UserId = userId,
            Website = "ww.google.com"
        };

        var controler = new ServiceController(mapperConfig.CreateMapper(), service);

        var result = controler.Update(news, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAllService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        var service1 = new Service
        {
            Id = id,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();

        var controler = new ServiceController(mapperConfig.CreateMapper(), service);
        var result = controler.GetAll(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        var service1 = new Service
        {
            Id = id,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();

        var controler = new ServiceController(mapperConfig.CreateMapper(), service);

        var result = controler.Get(userId, id);
        var result2 = (NotFoundResult)controler.Get(userId, 999);

        Assert.That(result, Is.Not.Null);
        Assert.That(result2.StatusCode, Is.EqualTo(404));
    }
}