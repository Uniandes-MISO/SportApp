
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
    
}
