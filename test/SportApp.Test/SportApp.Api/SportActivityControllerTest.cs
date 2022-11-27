using AutoMapper;
using SportApp.Api.Controllers;
using SportApp.Core.Dtos;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class SportActivityControllerTest
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
    public void GetAll()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        SportActivityService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var controler = new SportActivityController(service, mapperConfig.CreateMapper());
        var result = controler.GetAll(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Get()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        SportActivityService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var controler = new SportActivityController(service, mapperConfig.CreateMapper());
        var result = controler.Get(userId, 1);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Create()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        SportActivityService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var dto = new SportActivityDto
        {
            Id = id,
            UserId = userId,
            Distance = 10,
            Type = "KM",
            Name = "Test",
            Start = DateTime.Now,
            End = DateTime.Now
        };

        var controler = new SportActivityController(service, mapperConfig.CreateMapper());
        var result = controler.Create(dto, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Update()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        SportActivityService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var dto = new SportActivityDto
        {
            Id = id,
            UserId = userId,
            Distance = 10,
            Type = "Cycling",
            Measure = "Km",
            Name = "Test",
            Start = DateTime.Now,
            End = DateTime.Now
        };

        var controler = new SportActivityController(service, mapperConfig.CreateMapper());
        _ = controler.Create(dto, CancellationToken.None);
        dto.Name = "Salida";
        var result = controler.Update(dto, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }
}