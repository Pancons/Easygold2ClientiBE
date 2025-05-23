using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Ruoli;

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
