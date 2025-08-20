using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IAliQuoteIVARepository
    {
        Task<(IEnumerable<DbAliQuoteIVA>, int total)> GetAllAsync(AliQuoteIVAListRequest filter, string language);
        Task<DbAliQuoteIVA> GetByIdAsync(int id, string language);
        Task AddAsync(DbAliQuoteIVA entity, string language);
        Task UpdateAsync(DbAliQuoteIVA entity, string language);
        Task DeleteAsync(int id);
    }
}