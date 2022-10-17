using SportApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;


namespace SportApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.SetInitializer<AppDbContext>(new MyInitializer());
        }

        public AppDbContext() 
        {
           
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Host=host.docker.internal;Port=49153;Database=SportApp;Username=postgres;Password=postgrespw;CommandTimeout=300");
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
                        
        }

        public void Initialize()
        {
            // Init DB
            Database.EnsureCreated();

            // Seed data
            //if (!Employees.Any())
            //    Employees.AddRange(GetEmployees());

            //if (!TransitionSets.Any())
            //    TransitionSets.AddRange(GetDefaultTransitionSets());

            SaveChanges();
        }


        //public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
        //{
        //    protected override void Seed(DatabaseContext context)
        //    {
        //        context.Users.Add(
        //            new User()
        //            {
        //                Name = "Ali Yasin",
        //                SurName = "DOĞAN",
        //                Email = "a.yasindogan@gmail.com",
        //                Password = "12345"
        //            });
        //        context.SaveChanges();
        //    }
        //}


    }
}
