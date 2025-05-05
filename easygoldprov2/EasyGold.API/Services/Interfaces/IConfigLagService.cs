using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.ConfigLag;

namespace EasyGold.API.Services.Interfaces
{
    public interface IConfigLagService
    {
        Task<BaseListResponse<ConfigLagDTO>> GetAllAsync(BaseListRequest request);
        Task<ConfigLagDTO> GetByIdAsync(int isoNum, int id);
        Task<ConfigLagDTO> AddAsync(ConfigLagDTO dto);
        Task<ConfigLagDTO> UpdateAsync(ConfigLagDTO dto);
        Task DeleteAsync(int isoNum, int id);
    }
}