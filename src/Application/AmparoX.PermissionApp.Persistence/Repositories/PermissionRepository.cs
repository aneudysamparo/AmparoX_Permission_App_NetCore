using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Persistence.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Permission>> GetAllWithTypes()
        {
            return await AppDbContext.Permissions.Include(x => x.PermissionType).ToListAsync();
        }

        public async Task<Permission> GetByIdWithType(int Id)
        {
            return await AppDbContext.Permissions.Include(x => x.PermissionType).SingleOrDefaultAsync(x => x.Id == Id);
        }

        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
