using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Nazioni;

namespace EasyGold.API.Services.Interfaces
{
    public interface INazioneService
    {
       
        Task<BaseListResponse<NazioniDTO>> GetAllAsync(NazioniListRequest request);
        Task<NazioniDTO> GetByIdAsync(int id);
    }
}