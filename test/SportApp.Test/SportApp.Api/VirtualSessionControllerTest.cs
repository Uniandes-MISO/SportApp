using AutoMapper;
using SportApp.Api.Controllers;
using SportApp.Core.Dtos;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class VirtualSessionControllerTest
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
    public void Create()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        VirtualSessionService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var vit = new VirtualSessionDto
        {
            Id = 1,
            AthleteId = userId,
            TrainerId = userId,
            SportType = "Athletics",
            HourKey = "Seis",
            Date = DateTime.Now
        };

        var controler = new VirtualSessionController(service, mapperConfig.CreateMapper());
        var result = controler.Create(vit, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAll()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        VirtualSessionService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new VirtualSessionController(service, mapperConfig.CreateMapper());

        var result = controler.GetAll("Athletics", "2022-11-26");

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetByUser()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        VirtualSessionService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new VirtualSessionController(service, mapperConfig.CreateMapper());

        var result = controler.GetByUser(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAllTest()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        VirtualSessionService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new VirtualSessionController(service, mapperConfig.CreateMapper());

        var result = controler.GetAllTest("2022-11-26");

        Assert.That(result, Is.Not.Null);
    }
}