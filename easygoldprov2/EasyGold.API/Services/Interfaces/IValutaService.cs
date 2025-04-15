using EasyGold.API.Models;
using EasyGold.API.Models.Valute;

namespace EasyGold.API.Services.Interfaces
{
    public interface IValutaService
    {
       
        Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest request);
        Task<ValuteDTO> GetByIdAsync(int id);
    }
}