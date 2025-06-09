using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IRuoloService
    {
        Task<BaseListResponse<RuoloDTO>> GetAllRolesAsync();
        Task<RuoloDTO> GetRoleByIdAsync(int id);
        Task AddRoleAsync(RuoloDTO ruolo);
        Task UpdateRoleAsync(RuoloDTO ruolo);
        Task DeleteRoleAsync(int id);
    }
}
