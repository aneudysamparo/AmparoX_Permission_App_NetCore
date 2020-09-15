using AmparoX.PermissionApp.Domain;
using AmparoX.PermissionApp.Domain.Repositories;
using AmparoX.PermissionApp.Persistence.Repositories;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private PermissionRepository _permissionRepository;
        private PermissionTypeRepository _permissionTypeRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPermissionRepository Permissions => _permissionRepository = _permissionRepository ?? new PermissionRepository(_context);

        public IPermissionTypeRepository PermissionTypes => _permissionTypeRepository = _permissionTypeRepository ?? new PermissionTypeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
