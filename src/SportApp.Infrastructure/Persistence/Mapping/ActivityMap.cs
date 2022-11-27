using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> modelBuilder)
        {
            modelBuilder.HasKey(i => i.Id);

            modelBuilder.HasOne(i => i.Training)
                .WithMany(i => i.Activities)
                .HasForeignKey(i => i.TrainingId).OnDelete(DeleteBehavior.Cascade)
                .HasPrincipalKey(i => i.Id);
        }
    }
}