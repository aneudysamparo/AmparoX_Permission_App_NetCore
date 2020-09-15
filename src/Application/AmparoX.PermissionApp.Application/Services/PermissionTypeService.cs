using AmparoX.PermissionApp.Domain;
using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Application.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionType> Create(PermissionType permission)
        {
            await _unitOfWork.PermissionTypes.AddAsync(permission);
            await _unitOfWork.CommitAsync();
            return permission;
        }

        public async Task<IEnumerable<PermissionType>> GetAsync()
        {
            return await _unitOfWork.PermissionTypes.GetAllAsync();
        }

        public async Task<PermissionType> GetById(int Id)
        {
            return await _unitOfWork.PermissionTypes.GetByIdAsync(Id);
        }

        public async Task Remove(PermissionType permission)
        {
            _unitOfWork.PermissionTypes.Remove(permission);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(PermissionType permissionToEdit, PermissionType permission)
        {
            permissionToEdit.Description = permission.Description;

            await _unitOfWork.CommitAsync();
        }
    }
}
