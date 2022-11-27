using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class RouteMap : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> modelBuilder)
        {
        }
    }
}