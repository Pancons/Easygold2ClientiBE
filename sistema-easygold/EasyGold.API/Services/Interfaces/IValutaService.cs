using EasyGold.API.Models.Valute;

namespace EasyGold.API.Services.Interfaces
{
    public interface IValutaService
    {
       
        Task<IEnumerable<ValuteDTO>> GetAllAsync(ValuteListRequest request);
        Task<ValuteDTO> GetByIdAsync(int id);
    }
}