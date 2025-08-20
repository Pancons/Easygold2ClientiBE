using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ICausaliService
    {
        Task<BaseListResponse<CausaliDTO>> GetAllAsync(CausaliListRequest filter, string language);
        Task<CausaliDTO> GetByIdAsync(int id, string language);
        Task<CausaliDTO> AddAsync(CausaliDTO dto, string language);
        Task<CausaliDTO> UpdateAsync(CausaliDTO dto, string language);
        Task DeleteAsync(int id);
    }
}