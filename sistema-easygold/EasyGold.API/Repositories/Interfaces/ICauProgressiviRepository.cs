using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ICauProgressiviRepository
    {
        Task<(IEnumerable<DbCauProgressivi>, int total)> GetAllAsync(CauProgressiviListRequest filter, string language);
        Task<DbCauProgressivi> GetByIdAsync(int id, string language);
        Task AddAsync(DbCauProgressivi entity, string language);
        Task UpdateAsync(DbCauProgressivi entity, string language);
        Task DeleteAsync(int id);
    }
}