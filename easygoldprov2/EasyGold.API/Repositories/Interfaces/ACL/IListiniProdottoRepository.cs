using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IListiniProdottoRepository
    {
        Task<(IEnumerable<DbListiniProdotto>, int total)> GetAllAsync(ListiniProdottoListRequest filter, string language);
        Task<DbListiniProdotto> GetByIdAsync(int id, string language);
        Task AddAsync(DbListiniProdotto entity, string language);
        Task UpdateAsync(DbListiniProdotto entity, string language);
        Task DeleteAsync(int id);
    }
}