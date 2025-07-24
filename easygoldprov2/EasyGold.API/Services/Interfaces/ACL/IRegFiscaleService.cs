using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IRegFiscaleService
    {
        Task<BaseListResponse<RegFiscaleDTO>> GetAllAsync(RegFiscaleListRequest filter);
        Task<RegFiscaleDTO> GetByIdAsync(int id);
        Task<RegFiscaleDTO> AddAsync(RegFiscaleDTO dto);
        Task<RegFiscaleDTO> UpdateAsync(RegFiscaleDTO dto);
        Task DeleteAsync(int id);
    }
}