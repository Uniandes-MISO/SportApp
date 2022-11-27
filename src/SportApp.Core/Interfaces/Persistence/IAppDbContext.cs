using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<MembershipPlan> MembershipPlans { get; set; }

        DbSet<SportActivity> Activities { get; set; }

        DbSet<VirtualSession> VirtualSessions { get; set; }

        DbSet<Event> Events { get; set; }

        DbSet<Route> Routes { get; set; }

        DbSet<Service> Services { get; set; }

        DbSet<Training> Training { get; set; }

        DbSet<Activity> Activity { get; set; }

        DbSet<UserTraining> UserTraining { get; set; }

        DbSet<User> User { get; set; }

        DbSet<UserSchedule> UserSchedule { get; set; }

        DbSet<EatingRoutine> EatingRoutine { get; set; }

        DbSet<EatingRoutineBusiness> EatingRoutineBusiness { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}