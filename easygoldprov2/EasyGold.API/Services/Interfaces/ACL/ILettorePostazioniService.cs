using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ILettorePostazioniService
    {
        Task<BaseListResponse<LettorePostazioniDTO>> GetAllAsync(LettorePostazioniListRequest filter);
        Task<LettorePostazioniDTO> GetByIdAsync(int id);
        Task<LettorePostazioniDTO> AddAsync(LettorePostazioniDTO dto);
        Task<LettorePostazioniDTO> UpdateAsync(LettorePostazioniDTO dto);
        Task DeleteAsync(int id);
    }
}