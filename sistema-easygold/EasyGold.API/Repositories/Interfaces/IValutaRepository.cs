using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Valute;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IValutaRepository
    {
        Task<IEnumerable<DbValuta>> GetAllAsync(ValuteListRequest request);
        Task<DbValuta> GetByIdAsync(int id);
    }
}
