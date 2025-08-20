using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IOneriRivalutazioniService
    {
        Task<BaseListResponse<OneriRivalutazioniDTO>> GetAllAsync(OneriRivalutazioniListRequest filter, string language);
        Task<OneriRivalutazioniDTO> GetByIdAsync(int id, string language);
        Task<OneriRivalutazioniDTO> AddAsync(OneriRivalutazioniDTO dto, string language);
        Task<OneriRivalutazioniDTO> UpdateAsync(OneriRivalutazioniDTO dto, string language);
        Task DeleteAsync(int id);
    }
}