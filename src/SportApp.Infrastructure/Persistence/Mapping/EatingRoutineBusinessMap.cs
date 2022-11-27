using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class EatingRoutineBusinessMap : IEntityTypeConfiguration<EatingRoutineBusiness>
    {
        public void Configure(EntityTypeBuilder<EatingRoutineBusiness> modelBuilder)
        {
        }
    }
}