using EasyGold.Web2.Models.Comune.GEO;
using EasyGold.Web2.Models.Comune.Entities.GEO;

namespace EasyGold.API.Repositories.Interfaces.GEO
{
    public interface INazioneRepository
    {
        Task<IEnumerable<DbNazioni>> GetAllAsync(NazioniListRequest request);
        Task<DbNazioni> GetByIdAsync(int id);
    }
}
