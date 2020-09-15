using AmparoX.PermissionApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Domain.Repositories
{
    public interface IPermissionRepository: IRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllWithTypes();
        Task<Permission> GetByIdWithType(int Id);
    }
}
