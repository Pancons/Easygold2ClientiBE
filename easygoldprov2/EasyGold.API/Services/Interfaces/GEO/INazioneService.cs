using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.GEO;

namespace EasyGold.API.Services.Interfaces.GEO
{
    public interface INazioneService
    {

        Task<BaseListResponse<NazioniDTO>> GetAllAsync(NazioniListRequest request);
        Task<NazioniDTO> GetByIdAsync(int id);
    }
}