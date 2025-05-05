using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IConfigLagRepository
    {
        Task<IEnumerable<DbConfigLag>> GetAllAsync();
        Task<DbConfigLag> GetByIdAsync(int isoNum, int id);
        Task AddAsync(DbConfigLag entity);
        Task UpdateAsync(DbConfigLag entity);
        Task DeleteAsync(int isoNum, int id);
    }
}