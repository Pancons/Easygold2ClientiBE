using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.Config;

namespace EasyGold.API.Services.Interfaces
{
    public interface IConfigService
    {
        Task<BaseListResponse<ConfigDTO>> GetAllAsync(BaseListRequest request);
        Task<ConfigDTO> GetByIdAsync(int id);
        Task<ConfigDTO> AddAsync(ConfigDTO dto);
        Task<ConfigDTO> UpdateAsync(ConfigDTO dto);
        Task DeleteAsync(int id);
    }
}