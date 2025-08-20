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
    public interface ICausaliComuneRepository
    {
        Task<(IEnumerable<DbCausaliComune>, int total)> GetAllAsync(CausaliComuneListRequest filter, string language);
        Task<DbCausaliComune> GetByIdAsync(int id, string language);
        Task AddAsync(DbCausaliComune entity, string language);
        Task UpdateAsync(DbCausaliComune entity, string language);
        Task DeleteAsync(int id);
    }
}