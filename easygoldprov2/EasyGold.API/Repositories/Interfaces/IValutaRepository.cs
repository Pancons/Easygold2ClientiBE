using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Valute;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IValutaRepository
    {
        Task<IEnumerable<DbValute>> GetAllAsync(ValuteListRequest request);
        Task<DbValute> GetByIdAsync(int id);
    }
}
