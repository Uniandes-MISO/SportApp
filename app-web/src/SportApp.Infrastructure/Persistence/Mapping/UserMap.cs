using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("Users");
            modelBuilder.HasKey(i => i.Id);
            modelBuilder.Property(p => p.Email).HasMaxLength(50).IsRequired(true);
            modelBuilder.Property(p => p.FirstName).HasMaxLength(10).IsRequired(true);
            modelBuilder.Property(p => p.LastName).HasMaxLength(50).IsRequired(false);
        }
    }

}
