using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface INumeriRegIVARepository
    {
        Task<IEnumerable<DbNumeriRegIVA>> GetAllAsync();
        Task<DbNumeriRegIVA> GetByIdAsync(int id);
        Task AddAsync(DbNumeriRegIVA entity);
        Task UpdateAsync(DbNumeriRegIVA entity);
        Task DeleteAsync(int id);
    }
}