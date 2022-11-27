using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class SportActivityMap : IEntityTypeConfiguration<SportActivity>
    {
        public void Configure(EntityTypeBuilder<SportActivity> modelBuilder)
        {
        }
    }
}