using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IFunzioniRepository
    {
        Task<(IEnumerable<DbFunzioni>, int total)> GetAllAsync(FunzioniListRequest filter, string language);
        Task<DbFunzioni> GetByIdAsync(int id, string language);
        Task AddAsync(DbFunzioni entity,  string language);
        Task UpdateAsync(DbFunzioni entity,  string language);
        Task DeleteAsync(int id);
    }
}