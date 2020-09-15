using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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


            // Seed Dummy Data
            var data = new List<PermissionType>();
            data.Add(new PermissionType { Id = 1, Description = "School" });
            data.Add(new PermissionType { Id = 2, Description = "Sickness" });
            data.Add(new PermissionType { Id = 3, Description = "Vacation" });
            data.Add(new PermissionType { Id = 4, Description = "Other" });

            builder.Entity<PermissionType>().HasData(data);
        }
    }
}
