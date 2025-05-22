using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IAliquoteIVARepository
    {
        Task<IEnumerable<DbAliquoteIVA>> GetAllAsync();
        Task<DbAliquoteIVA> GetByIdAsync(int id);
        Task AddAsync(DbAliquoteIVA entity);
        Task UpdateAsync(DbAliquoteIVA entity);
        Task DeleteAsync(int id);
    }
}