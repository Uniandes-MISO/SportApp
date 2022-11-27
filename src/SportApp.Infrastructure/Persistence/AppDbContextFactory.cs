using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SportApp.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseNpgsql("Host=sportapp.cwmm9a477x2f.us-east-1.rds.amazonaws.com;Port=5432;Database=SportApp;Username=postgres;Password=postgres*;CommandTimeout=300");
            optionsBuilder.UseNpgsql("Host=host.docker.internal;Port=5432;Database=SportApp;Username=postgres;Password=postgres;CommandTimeout=300");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}