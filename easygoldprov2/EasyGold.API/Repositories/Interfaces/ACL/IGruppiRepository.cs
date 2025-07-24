using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IGruppiRepository
    {
        Task<(IEnumerable<DbGruppi>, int total)> GetAllAsync(GruppiListRequest filter, string language);
        Task<DbGruppi> GetByIdAsync(int id, string language);
        Task AddAsync(DbGruppi entity, string language);
        Task UpdateAsync(DbGruppi entity, string language);
        Task DeleteAsync(int id);
    }
}