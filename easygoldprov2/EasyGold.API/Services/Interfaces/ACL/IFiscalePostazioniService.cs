using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IFiscalePostazioniService
    {
        Task<BaseListResponse<FiscalePostazioniDTO>> GetAllAsync(FiscalePostazioniListRequest request);
        Task<FiscalePostazioniDTO> GetByIdAsync(int id);
        Task<FiscalePostazioniDTO> AddAsync(FiscalePostazioniDTO dto);
        Task<FiscalePostazioniDTO> UpdateAsync(FiscalePostazioniDTO dto);
        Task DeleteAsync(int id);
    }
}