using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IModuliStampeRepository
    {
        Task<(IEnumerable<DbModuliStampe>, int total)> GetAllAsync(ModuliStampeListRequest filter);
        Task<DbModuliStampe> GetByIdAsync(int id);
        Task AddAsync(DbModuliStampe entity);
        Task UpdateAsync(DbModuliStampe entity);
        Task DeleteAsync(int id);
    }
}