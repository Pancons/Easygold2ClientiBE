using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;

namespace EasyGold.API.Services.Interfaces.ConfigProgramma
{
    public interface IConfigLangService
    {
        Task<BaseListResponse<ConfigLangDTO>> GetAllAsync(BaseListRequest request);
        Task<ConfigLangDTO> GetByIdAsync(int isoNum, int id);
        Task<ConfigLangDTO> AddAsync(ConfigLangDTO dto);
        Task<ConfigLangDTO> UpdateAsync(ConfigLangDTO dto);
        Task DeleteAsync(int isoNum, int id);
    }
}