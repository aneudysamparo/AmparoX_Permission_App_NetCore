using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Domain.Repositories;

namespace AmparoX.PermissionApp.Persistence.Repositories
{
    public class PermissionTypeRepository: Repository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(AppDbContext context) : base(context) { }

        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
