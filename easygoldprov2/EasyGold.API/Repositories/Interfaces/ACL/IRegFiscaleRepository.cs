using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IRegFiscaleRepository
    {
        Task<(IEnumerable<DbRegFiscale> lista, int totale)> GetAllAsync(RegFiscaleListRequest filter);
        Task<DbRegFiscale> GetByIdAsync(int id);
        Task AddAsync(DbRegFiscale entity);
        Task UpdateAsync(DbRegFiscale entity);
        Task DeleteAsync(int id);
    }
}