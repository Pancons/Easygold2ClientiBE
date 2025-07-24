using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IModuliStampeService
    {
        Task<BaseListResponse<ModuliStampeDTO>> GetAllAsync(ModuliStampeListRequest filter);
        Task<ModuliStampeDTO> GetByIdAsync(int id);
        Task<ModuliStampeDTO> AddAsync(ModuliStampeDTO dto);
        Task<ModuliStampeDTO> UpdateAsync(ModuliStampeDTO dto);
        Task DeleteAsync(int id);
    }
}