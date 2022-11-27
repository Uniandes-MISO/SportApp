using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportApp.Core.Entities;

namespace SportApp.Infrastructure.Persistence.Mapping
{
    public class VirtualSessionMap : IEntityTypeConfiguration<VirtualSession>
    {
        public void Configure(EntityTypeBuilder<VirtualSession> modelBuilder)
        {
        }
    }
}