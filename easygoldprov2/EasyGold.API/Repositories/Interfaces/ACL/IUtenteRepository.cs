using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtenteRepository
    {
        Task<(IEnumerable<DbUtente> Users, int Total)> GetAllAsync(BaseListRequest request);
        Task<DbUtente> GetByIdAsync(int id);
        Task AddAsync(DbUtente entity);
        Task UpdateAsync(DbUtente entity);
        Task DeleteAsync(int id);
    }
}