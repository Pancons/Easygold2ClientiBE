using EasyGold.Web2.Models.Comune.Valute;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface IValutaRepository
    {
        Task<IEnumerable<DbValute>> GetAllAsync(ValuteListRequest request);
        Task<DbValute> GetByIdAsync(int id);
    }
}
