using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.GEO
{
    public interface INazioneNegozioRepository
    {
        Task<IEnumerable<DbNazioneNegozio>> GetAllAsync();
        Task<DbNazioneNegozio> GetByIdAsync(int id);
        Task AddAsync(DbNazioneNegozio entity);
        Task UpdateAsync(DbNazioneNegozio entity);
        Task DeleteAsync(int id);
    }
}