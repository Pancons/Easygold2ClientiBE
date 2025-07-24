using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITipoPwService
    {
        Task<BaseListResponse<TipoPwDTO>> GetAllAsync(TipoPwListRequest request);
        Task<TipoPwDTO> GetByIdAsync(int id);
        Task<TipoPwDTO> AddAsync(TipoPwDTO dto);
        Task<TipoPwDTO> UpdateAsync(TipoPwDTO dto);
        Task DeleteAsync(int id);
    }
}
