using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IPwUtentiRepository
    {
        Task<(IEnumerable<DbPwUtenti>, int total)> GetAllAsync(PwUtentiListRequest filter);
        Task<DbPwUtenti> GetByIdAsync(int id);
        Task AddAsync(DbPwUtenti entity);
        Task UpdateAsync(DbPwUtenti entity);
        Task DeleteAsync(int id);
    }
}