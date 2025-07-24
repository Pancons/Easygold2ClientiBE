using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INegozioRepository
    {
        Task<(IEnumerable<DbNegozi>, int)> GetAllAsync(NegozioListRequest filter);
        Task<DbNegozi> GetByIdAsync(int id);
        Task AddAsync(DbNegozi negozio);
        Task UpdateAsync(DbNegozi negozio);
        Task DeleteAsync(int id);
    }
}
