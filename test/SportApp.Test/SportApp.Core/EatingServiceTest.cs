using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class EatingServiceTest
{
    [Test]
    public void GetAllAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        EatingRoutineService service = new(context);

        var userId = Guid.NewGuid().ToString();
        context.User.Add(new User()
        {
            Id = userId,
            FirstName = "FirstName",
            LastName = "LastName"
        });
        var id = new Random().Next(1, 99999);
        var eating = new EatingRoutine
        {
            Id = id,
            Name = "Test",
            Description = "",
            Image = ""
        };
        context.EatingRoutine.Add(eating);
        var idser = new Random().Next(1, 99999);
        var service1 = new Service
        {
            Id = idser,
            Name = "Test",
            UserId = userId,
            SportType = SportType.Cycling,
            Type = ServiceType.Sportsman,
        };
        context.Services.Add(service1);

        var eabus = new EatingRoutineBusiness
        {
            EatingRoutineId = id,
            ServiceId = idser,
            EatingRoutine = new EatingRoutine { Id = 11, Description = "", Image = "", Name = "" }
            ,
        };
        context.EatingRoutineBusiness.Add(eabus);
        context.SaveChanges();

        var result = service.GetByUser(userId, 3);

        Assert.That(result, Is.Not.Null);
    }
}