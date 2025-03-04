using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Ruoli;

namespace EasyGold.API.Services.Interfaces
{
    public interface IRuoloService
    {
        Task<IEnumerable<RuoloDTO>> GetAllRolesAsync();
        Task<RuoloDTO> GetRoleByIdAsync(int id);
        Task AddRoleAsync(RuoloDTO ruolo);
        Task UpdateRoleAsync(RuoloDTO ruolo);
        Task DeleteRoleAsync(int id);
    }
}
