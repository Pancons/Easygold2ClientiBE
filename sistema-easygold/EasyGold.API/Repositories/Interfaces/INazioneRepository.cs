using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Nazioni;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface INazioneRepository
    {
        Task<IEnumerable<DbNazioni>> GetAllAsync(NazioniListRequest request);
        Task<DbNazioni> GetByIdAsync(int id);
    }
}
