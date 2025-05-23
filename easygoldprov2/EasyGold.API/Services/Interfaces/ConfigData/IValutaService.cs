using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Valute;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface IValutaService
    {

        Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest request);
        Task<ValuteDTO> GetByIdAsync(int id);
    }
}