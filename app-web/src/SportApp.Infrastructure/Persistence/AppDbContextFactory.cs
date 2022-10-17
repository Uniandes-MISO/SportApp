using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace SportApp.Infrastructure.Persistence
{

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=host.docker.internal;Port=49153;Database=SportApp;Username=postgres;Password=postgrespw;CommandTimeout=300");

            return new AppDbContext(optionsBuilder.Options);
        }

    }
}
