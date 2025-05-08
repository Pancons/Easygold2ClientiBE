using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;

namespace EasyGold.API.Services.Interfaces
{
    public interface IConfigService
    {
        Task<JsonDocument> GetParametriConfigurazione(int idNazione);
        Task<BaseListResponse<ConfigDTO>> GetAllAsync(BaseListRequest request);
        Task<ConfigDTO> GetByIdAsync(int id);
        Task<ConfigDTO> AddAsync(ConfigDTO dto);
        Task<ConfigDTO> UpdateAsync(ConfigDTO dto);
        Task DeleteAsync(int id);
    }
}