using AmparoX.PermissionApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmparoX.PermissionApp.Persistence.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
        }
    }
}
