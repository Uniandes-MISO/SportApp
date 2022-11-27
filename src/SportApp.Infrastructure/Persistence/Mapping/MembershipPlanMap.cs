using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class MembershipPlanMap : IEntityTypeConfiguration<MembershipPlan>
    {
        public void Configure(EntityTypeBuilder<MembershipPlan> modelBuilder)
        {
            /*modelBuilder.ToTable("Activities");
            modelBuilder.HasKey(i => i.Id);
            modelBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);*/
        }
    }
}