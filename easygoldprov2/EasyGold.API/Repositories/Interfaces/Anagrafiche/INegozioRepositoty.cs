using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INegozioRepository
    {
        Task<IEnumerable<DbNegozi>> GetAllAsync();
        Task<DbNegozi> GetByIdAsync(int id);
        Task AddAsync(DbNegozi negozio);
        Task UpdateAsync(DbNegozi negozio);
        Task DeleteAsync(int id);
    }
}
