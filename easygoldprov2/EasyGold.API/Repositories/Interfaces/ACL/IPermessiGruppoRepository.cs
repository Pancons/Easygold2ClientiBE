using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IPermessiGruppoRepository
    {
        Task<(IEnumerable<DbPermessiGruppo>, int total)> GetAllAsync(PermessiGruppoListRequest filter);
        Task<DbPermessiGruppo> GetByIdAsync(int id);
        Task AddAsync(DbPermessiGruppo entity);
        Task UpdateAsync(DbPermessiGruppo entity);
        Task DeleteAsync(int id);
    }
}