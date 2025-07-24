using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IStampePostazioniService
    {
        Task<BaseListResponse<StampePostazioniDTO>> GetAllAsync(StampePostazioniListRequest request);
        Task<StampePostazioniDTO> GetByIdAsync(int id);
        Task<StampePostazioniDTO> AddAsync(StampePostazioniDTO dto);
        Task<StampePostazioniDTO> UpdateAsync(StampePostazioniDTO dto);
        Task DeleteAsync(int id);
    }
}
