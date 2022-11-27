using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class ServiceServiceTest
{
    [Test]
    public void CreateService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var service1 = new Service
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId
        };

        var result = service.CreateAsync(service1, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void UpdateService()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var service1 = new Service
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();

        service1.Name = "Rename service";
        var result = service.UpdateAsync(service1, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var service1 = new Service
        {
            Id = 10,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();
        var result = service.GetAsync(userId, 10);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetAllAsync()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        ServiceService service = new(context);

        var userId = Guid.NewGuid().ToString();
        var service1 = new Service
        {
            Id = 20,
            Name = "Test",
            UserId = userId
        };
        context.Services.Add(service1);
        context.SaveChanges();
        var result = service.GetAllAsync(userId);

        Assert.That(result, Is.Not.Null);
    }
}