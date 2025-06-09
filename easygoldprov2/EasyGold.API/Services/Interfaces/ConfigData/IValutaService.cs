using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.Valute;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface IValutaService
    {

        Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest request);
        Task<ValuteDTO> GetByIdAsync(int id);
    }
}