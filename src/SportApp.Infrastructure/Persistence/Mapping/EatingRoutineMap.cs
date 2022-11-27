using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class SporEatingRoutineMap : IEntityTypeConfiguration<EatingRoutine>
    {
        public void Configure(EntityTypeBuilder<EatingRoutine> modelBuilder)
        {
        }
    }
}