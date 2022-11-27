using AutoMapper;
using SportApp.Api.Controllers;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class EventControlerTest
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
        EventService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);
        //
        context.SaveChanges();

        var controler = new EventController(mapperConfig.CreateMapper(), service);
        var result = controler.GetAll(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Get()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        EventService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new EventController(mapperConfig.CreateMapper(), service);

        var result = controler.Get(userId, "26-11-2022", "");

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetBy()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        EventService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new EventController(mapperConfig.CreateMapper(), service);

        var result = controler.GetBy(userId, new Api.Models.EventModel());

        Assert.That(result, Is.Not.Null);
    }
}