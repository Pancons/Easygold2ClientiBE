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
    public interface INazioniMondoRepository
    {
        Task<(IEnumerable<DbNazioniMondo>, int total)> GetAllAsync(NazioniMondoListRequest filter, string language);
        Task<DbNazioniMondo> GetByIdAsync(int id, string language);
        Task AddAsync(DbNazioniMondo entity, string language);
        Task UpdateAsync(DbNazioniMondo entity, string language);
        Task DeleteAsync(int id);
    }
}