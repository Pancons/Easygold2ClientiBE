using EasyGold.API.Models.Nazioni;

namespace EasyGold.API.Services.Interfaces
{
    public interface INazioneService
    {
       
        Task<IEnumerable<NazioniDTO>> GetAllAsync();
        Task<NazioniDTO> GetByIdAsync(int id);
    }
}