using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class TrainingServiceTest
{
    [Test]
    public void GetAllTraining()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        TrainingService service = new(context);

        var training = new Training
        {
            Id = new Random().Next(1, 99999),
            Name = "Test",
            Activities = new List<Activity>() { new Activity { Description = "", Name = "", Duration = "", Order = 1 } }
        };
        context.Training.Add(training);
        context.SaveChanges();

        var result = service.GetAllAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.GreaterThan(0));
    }

    [Test]
    public void GetAsyn()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        TrainingService service = new(context);

        var training = new Training
        {
            Id = new Random().Next(1, 99999),
            Name = "Test"
        };
        context.Training.Add(training);
        context.SaveChanges();
        var userId = Guid.NewGuid().ToString();
        var result = service.GetAsync(userId);

        Assert.That(result, Is.Not.Null);
    }
}