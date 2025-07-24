using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITipoPermessoService
    {
        Task<BaseListResponse<TipoPermessoDTO>> GetAllAsync(TipoPermessoListRequest request);
        Task<TipoPermessoDTO> GetByIdAsync(int id);
        Task<TipoPermessoDTO> AddAsync(TipoPermessoDTO dto);
        Task<TipoPermessoDTO> UpdateAsync(TipoPermessoDTO dto);
        Task DeleteAsync(int id);
    }
}
