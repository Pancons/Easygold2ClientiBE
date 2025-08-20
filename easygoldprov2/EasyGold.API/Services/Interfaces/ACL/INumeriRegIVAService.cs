using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface INumeriRegIVAService
    {
        Task<BaseListResponse<NumeriRegIVADTO>> GetAllAsync(NumeriRegIVAListRequest request);
        Task<NumeriRegIVADTO> GetByIdAsync(int id);
        Task<NumeriRegIVADTO> AddAsync(NumeriRegIVADTO dto);
        Task<NumeriRegIVADTO> UpdateAsync(NumeriRegIVADTO dto);
        Task DeleteAsync(int id);
    }
}