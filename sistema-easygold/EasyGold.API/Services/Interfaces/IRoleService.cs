using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Roles;

namespace EasyGold.API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RuoloDTO>> GetAllRolesAsync();
        Task<RuoloDTO> GetRoleByIdAsync(int id);
        Task AddRoleAsync(RuoloDTO ruolo);
        Task UpdateRoleAsync(RuoloDTO ruolo);
        Task DeleteRoleAsync(int id);
    }
}
