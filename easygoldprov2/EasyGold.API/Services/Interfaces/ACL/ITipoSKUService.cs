using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITipoSKUService
    {
        Task<BaseListResponse<TipoSKUDTO>> GetAllAsync(TipoSKUListRequest request);
        Task<TipoSKUDTO> GetByIdAsync(int id);
        Task<TipoSKUDTO> AddAsync(TipoSKUDTO dto);
        Task<TipoSKUDTO> UpdateAsync(TipoSKUDTO dto);
        Task DeleteAsync(int id);
    }
}