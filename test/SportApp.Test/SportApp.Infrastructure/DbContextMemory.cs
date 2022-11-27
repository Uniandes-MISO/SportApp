using Microsoft.EntityFrameworkCore;

namespace SportApp.Test.SportApp;

public static class DbContextMemory
{
    public static DbContextOptions<T> CreateContextOptions<T>(string nameDatabase)
        where T : DbContext
    {
        var options = new DbContextOptionsBuilder<T>()
        .UseInMemoryDatabase(databaseName: nameDatabase)
        .Options;

        return options;
    }
}