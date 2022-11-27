using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class UserScheduleMap : IEntityTypeConfiguration<UserSchedule>
    {
        public void Configure(EntityTypeBuilder<UserSchedule> modelBuilder)
        {
        }
    }
}