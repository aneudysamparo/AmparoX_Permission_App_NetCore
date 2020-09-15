using AmparoX.PermissionApp.Domain;
using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Application.Services
{
    public class PermissionService: IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Permission> Create(Permission permission)
        {
            await _unitOfWork.Permissions.AddAsync(permission);
            await _unitOfWork.CommitAsync();
            return permission;
        }

        public async Task<IEnumerable<Permission>> GetAsync()
        {
            return await _unitOfWork.Permissions.GetAllWithTypes();
        }

        public async Task<Permission> GetById(int Id)
        {
            return await _unitOfWork.Permissions.GetByIdWithType(Id);
        }

        public async Task Remove(Permission permission)
        {
            _unitOfWork.Permissions.Remove(permission);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Permission permissionToEdit, Permission permission)
        {
            permissionToEdit.LastName = permission.LastName;
            permissionToEdit.FirstName = permission.FirstName;
            permissionToEdit.Date = permission.Date;
            permissionToEdit.PermissionTypeId = permission.PermissionTypeId;

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllWithTypes()
        {
            return await _unitOfWork.Permissions.GetAllWithTypes();
        }
    }
}
