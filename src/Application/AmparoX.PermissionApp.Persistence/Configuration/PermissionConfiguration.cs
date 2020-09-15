using AmparoX.PermissionApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmparoX.PermissionApp.Persistence.Configuration
{
    public class PermissionConfiguration: IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();

        }
    }
}
