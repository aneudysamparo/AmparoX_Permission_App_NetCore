using AmparoX.PermissionApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Domain.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAsync();
        Task<Permission> GetById(int Id);
        Task<Permission> Create(Permission permission);
        Task Update(Permission permissionToEdit, Permission permission);
        Task Remove(Permission permission);
    }
}
