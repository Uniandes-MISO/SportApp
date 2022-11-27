using AutoMapper;
using SportApp.Api.Controllers;
using SportApp.Core.Dtos;
using SportApp.Core.Mappings;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class UserTrainingControllerTest
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
        UserTrainingService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var dto = new UserTrainingDto
        {
            Id = 234,
            DateTime = DateTime.Now,
            TrainingId = 1,
            UserId = userId
        };

        var controler = new UserTrainingController(mapperConfig.CreateMapper(), service);

        var result = controler.Create(dto, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Get()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        UserTrainingService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var id = new Random().Next(1, 99999);

        context.SaveChanges();

        var controler = new UserTrainingController(mapperConfig.CreateMapper(), service);

        var result = controler.Get(userId);

        Assert.That(result, Is.Not.Null);
    }
}