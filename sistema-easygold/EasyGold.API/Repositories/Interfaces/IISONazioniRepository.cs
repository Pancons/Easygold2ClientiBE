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
    public interface IISONazioniRepository
    {
        Task<(IEnumerable<DbISONazioni> items, int total)> GetAllAsync(ISONazioniListRequest request);
        Task<DbISONazioni> GetByIdAsync(int id);
        Task AddAsync(DbISONazioni entity);
        Task<DbISONazioni> UpdateAsync(DbISONazioni entity);
        Task DeleteAsync(int id);
    }
}