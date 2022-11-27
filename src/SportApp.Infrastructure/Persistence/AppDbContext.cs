using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<User>, IAppDbContext //IdentityDbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<MembershipPlan> MembershipPlans { get; set; }

        public DbSet<VirtualSession> VirtualSessions { get; set; }

        public DbSet<SportActivity> Activities { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Training> Training { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<UserTraining> UserTraining { get; set; }

        public DbSet<UserSchedule> UserSchedule { get; set; }

        public DbSet<EatingRoutine> EatingRoutine { get; set; }

        public DbSet<EatingRoutineBusiness> EatingRoutineBusiness { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User user = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@sportapp.com",
                Email = "admin@sportapp.com",
                LockoutEnabled = false,
                FirstName = "Sport",
                LastName = "App",
                PhoneNumber = "",
            };

            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();

            user.PasswordHash = passwordHasher.HashPassword(user, "SportApp*");

            builder.Entity<User>().HasData(user);

            User userAthlete = new()
            {
                Id = "a079d055-d181-4692-9146-fed8c18a989d",
                UserName = "user1@sportapp.com",
                Email = "user1@sportapp.com",
                LockoutEnabled = false,
                FirstName = "User",
                LastName = "Athlete",
                PhoneNumber = "",
            };

            userAthlete.NormalizedEmail = userAthlete.Email.ToUpper();
            userAthlete.NormalizedUserName = userAthlete.UserName.ToUpper();
            userAthlete.PasswordHash = passwordHasher.HashPassword(userAthlete, "user1*");
            builder.Entity<User>().HasData(userAthlete);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Athlete", ConcurrencyStamp = "2", NormalizedName = "ATHLETE" },
                new IdentityRole() { Id = "687c5aa4-c079-4e48-b7a1-8a69341c4f26", Name = "Partner", ConcurrencyStamp = "3", NormalizedName = "PARTNER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "a079d055-d181-4692-9146-fed8c18a989d" }
               );
        }

        public void Initialize()
        {
            // Init DB
            Database.EnsureCreated();

            // Seed data

            SaveChanges();
        }
    }
}