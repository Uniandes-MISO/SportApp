using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class VirtualSessionServiceTest
{
    [Test]
    public void CreateVirtualSessionService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        var userId = Guid.NewGuid().ToString();
        context.User.Add(new User()
        {
            Id = userId,
            FirstName = "FirstName",
            LastName = "LastName"
        });

        VirtualSessionDto data = new()
        {
            Id = 1,
            HourKey = "Dies",
            SportType = "Cycling",
            TrainerId = userId,
            Date = DateTime.Now,
            AthleteId = userId,
        };
        context.SaveChanges();

        //UserTraining data = new();
        //data.UserId = userId;
        //data.TrainingId = training;
        //data.DateTime = DateTime.Now;

        VirtualSessionService service = new(context);
        service.InsertOrUpdateAsync(data, CancellationToken.None).Wait();
        var result = service.GetAllAsync(userId).ToList();
        var result1 = service.GetAsync(userId, SportType.Athletics).ToList();

        Assert.That(result, Is.Not.Null);
        Assert.That(result1, Is.Not.Null);
        //Assert.That(result.Count, Is.GreaterThan(0));
    }

    [Test]
    public void GetCoachAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        var userId = Guid.NewGuid().ToString();
        context.User.Add(new User()
        {
            Id = userId,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "user1@test.com",
        });

        context.Services.Add(new Service()
        {
            Id = 1,
            UserId = userId,
            Email = "test@test.com",
            SportType = SportType.Cycling,
            Name = "Service Cycling",
            Description = "",
            Phone = "320000",
            Type = ServiceType.Sportsman,
            Website = ""
        });

        context.Services.Add(new Service()
        {
            Id = 2,
            UserId = userId,
            Email = "test@test.com",
            SportType = SportType.Athletics,
            Name = "Service Athletics",
            Description = "",
            Phone = "320000",
            Type = ServiceType.Coach,
            Website = ""
        });

        context.SaveChanges();

        VirtualSessionService service = new(context);

        var resultAll = service.GetCoachAsync("Athletics", new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day)).ToList();
        Assert.That(resultAll, Is.Not.Null);
    }
}