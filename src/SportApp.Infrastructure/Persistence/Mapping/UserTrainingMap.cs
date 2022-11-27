using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class UserTrainingMap : IEntityTypeConfiguration<UserTraining>
    {
        public void Configure(EntityTypeBuilder<UserTraining> modelBuilder)
        {
            //modelBuilder.HasKey(i => i.Id);

            //modelBuilder.HasOne(i => i.User)
            //    .WithMany(i => i.Trainings)
            //    .HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade)
            //    .HasPrincipalKey(i => i.Id);
        }
    }
}