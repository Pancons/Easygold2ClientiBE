using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICauProgressiviRepository
    {
        Task<IEnumerable<DbCauProgressivi>> GetAllAsync();
        Task<DbCauProgressivi> GetByIdAsync(int id);
        Task AddAsync(DbCauProgressivi entity);
        Task UpdateAsync(DbCauProgressivi entity);
        Task DeleteAsync(int id);
    }
}