using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IConfigService
    {
        Task<BaseListResponse<ConfigDTO>> GetAllAsync(ConfigListRequest filter, string language);
        Task<ConfigDTO> GetByIdAsync(int id, string language);
        Task<ConfigDTO> AddAsync(ConfigDTO dto, string language);
        Task<ConfigDTO> UpdateAsync(ConfigDTO dto, string language);
        Task DeleteAsync(int id);
    }
}