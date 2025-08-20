using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IRegIVAService
    {
        Task<BaseListResponse<RegIVADTO>> GetAllAsync(RegIVAListRequest request);
        Task<RegIVADTO> GetByIdAsync(int id);
        Task<RegIVADTO> AddAsync(RegIVADTO dto);
        Task<RegIVADTO> UpdateAsync(RegIVADTO dto);
        Task DeleteAsync(int id);
    }
}