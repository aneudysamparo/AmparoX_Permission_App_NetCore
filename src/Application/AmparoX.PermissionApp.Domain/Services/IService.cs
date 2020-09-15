using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmparoX.PermissionApp.Domain.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetById(int Id);
        Task<T> Create(T permission);
        Task Update(T permissionToEdit, T permission);
        Task Remove(T permission);
    }
}
