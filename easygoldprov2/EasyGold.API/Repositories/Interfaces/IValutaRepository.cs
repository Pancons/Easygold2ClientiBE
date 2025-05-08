using EasyGold.API.Models.DTO.Valute;
using EasyGold.API.Models.Entities.Valute;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IValutaRepository
    {
        Task<IEnumerable<DbValute>> GetAllAsync(ValuteListRequest request);
        Task<DbValute> GetByIdAsync(int id);
    }
}
