using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
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