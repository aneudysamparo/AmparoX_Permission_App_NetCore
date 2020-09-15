using AmparoX.PermissionApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Domain.Services
{
    public interface IPermissionTypeService
    {
        Task<IEnumerable<PermissionType>> GetAsync();
        Task<PermissionType> GetById(int Id);
        Task<PermissionType> Create(PermissionType permissionType);
        Task Update(PermissionType permissionTypeToEdit, PermissionType permissionType);
        Task Remove(PermissionType permissionType);
    }
}
