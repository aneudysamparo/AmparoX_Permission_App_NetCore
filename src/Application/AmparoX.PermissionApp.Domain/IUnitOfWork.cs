using AmparoX.PermissionApp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        IPermissionRepository Permissions { get; }
        IPermissionTypeRepository PermissionTypes { get; }
        Task<int> CommitAsync();
    }
}
