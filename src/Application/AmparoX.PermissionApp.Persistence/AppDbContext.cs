using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AmparoX.PermissionApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new PermissionTypeConfiguration());
        }
    }
}
