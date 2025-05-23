using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICauOrdinamentoRepository
    {
        Task<IEnumerable<DbCauOrdinamento>> GetAllAsync();
        Task<DbCauOrdinamento> GetByIdAsync(int id);
        Task AddAsync(DbCauOrdinamento entity);
        Task UpdateAsync(DbCauOrdinamento entity);
        Task DeleteAsync(int id);
    }
}