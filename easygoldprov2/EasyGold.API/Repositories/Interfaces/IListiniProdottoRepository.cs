using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IListiniProdottoRepository
    {
        Task<IEnumerable<DbListiniProdotto>> GetAllAsync();
        Task<DbListiniProdotto> GetByIdAsync(int id);
        Task AddAsync(DbListiniProdotto entity);
        Task UpdateAsync(DbListiniProdotto entity);
        Task DeleteAsync(int id);
    }
}