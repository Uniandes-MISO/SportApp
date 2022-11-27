using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class RouteServiceTest
{
    [Test]
    public void GetAllAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        RouteService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var route = new Route
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId,
            Description = "",
            ImageURl = "",
            Site = ""
        };
        context.Routes.Add(route);
        context.SaveChanges();

        var result = service.GetAllAsync(userId);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        RouteService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var route = new Route
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId,
            Description = "",
            ImageURl = "",
            Site = "Site"
        };
        context.Routes.Add(route);
        context.SaveChanges();

        var result = service.GetAsync(userId, "Site");

        Assert.That(result, Is.Not.Null);
    }
}