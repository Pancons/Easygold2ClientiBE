using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INazioneFiscoRepository
    {   
        Task<(IEnumerable<DbNazioneFisco> items, int total)> GetAllAsync(NazioneFiscoListRequest request);
        Task<DbNazioneFisco> GetByIdAsync(int id);
        Task AddAsync(DbNazioneFisco entity);
        Task<DbNazioneFisco> UpdateAsync(DbNazioneFisco entity);
        Task DeleteAsync(int id);
    }
}