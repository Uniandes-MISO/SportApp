using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class EventServiceTest
{
    [Test]
    public void GetAllAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        EventService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var events = new Event
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId,
            Description = "",
            ImageURl = "",
            Site = ""
        };
        context.Events.Add(events);
        context.SaveChanges();

        var result = service.GetAllAsync(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        EventService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var events = new Event
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId,
            Description = "",
            ImageURl = "",
            Site = "Site",
            Date = DateTime.Now,
        };
        context.Events.Add(events);
        context.SaveChanges();

        var result = service.GetAsync(userId, $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}", "Site");

        Assert.That(result, Is.Not.Null);
    }
}