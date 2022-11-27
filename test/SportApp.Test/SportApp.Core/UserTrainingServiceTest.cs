using SportApp.Core.Entities;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;

namespace SportApp.Test.SportApp.Core;

[TestFixture]
public class UserTrainingServiceTest
{
    [Test]
    public void CreateUserTraining()
    {
        AppDbContext context = new(DbContextMemory.CreateContextOptions<AppDbContext>("SportApp"));
        var userId = Guid.NewGuid().ToString();
        context.User.Add(new User()
        {
            Id = userId,
            FirstName = "FirstName",
            LastName = "LastName"
        });
        var training = new Random().Next(1, 99999);
        context.Training.Add(new Training
        {
            Id = training,
            Name = "Test"
        });
        context.SaveChanges();

        UserTraining data = new();
        data.UserId = userId;
        data.TrainingId = training;
        data.DateTime = DateTime.Now;

        UserTrainingService service = new(context);
        service.CreateAsync(data, CancellationToken.None).Wait();
        var result = service.GetAsync(userId).ToList();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.GreaterThan(0));
    }
}