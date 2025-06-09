using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ConfigProgramma;

namespace EasyGold.API.Services.Interfaces.ConfigProgramma
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