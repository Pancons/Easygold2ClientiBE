using EasyGold.API.Models.DTO.Nazioni;
using EasyGold.API.Models.Entities.Nazioni;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface INazioneRepository
    {
        Task<IEnumerable<DbNazioni>> GetAllAsync(NazioniListRequest request);
        Task<DbNazioni> GetByIdAsync(int id);
    }
}
