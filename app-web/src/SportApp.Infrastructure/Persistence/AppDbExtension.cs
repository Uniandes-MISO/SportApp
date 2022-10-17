using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportApp.Core.Interfaces;
using SportApp.Infrastructure.Persistence.Config;

namespace SportApp.Infrastructure.Persistence
{

    public static class AppDbExtension
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresConfig = configuration.GetSection(PostgresSettings.SectionName).Get<PostgresSettings>();
            services.AddSingleton(postgresConfig);

            var name = typeof(AppDbContext).Assembly.FullName;

            services.AddDbContext<IAppDbContext, AppDbContext>(
                opt => opt.UseNpgsql(postgresConfig.ConnectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(name)));
        }

        public static void RunDbContextMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<IAppDbContext>();
            dbContext?.Database.Migrate();
        }
    }

}
