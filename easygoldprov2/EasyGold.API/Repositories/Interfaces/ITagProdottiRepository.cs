using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ITagProdottiRepository
    {
        Task<IEnumerable<DbTagProdotti>> GetAllAsync();
        Task<DbTagProdotti> GetByIdAsync(int id);
        Task AddAsync(DbTagProdotti entity);
        Task UpdateAsync(DbTagProdotti entity);
        Task DeleteAsync(int id);
    }
}