using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.NumeriRegIVA;

namespace EasyGold.API.Services.Interfaces
{
    public interface INumeriRegIVAService
    {
        Task<BaseListResponse<NumeriRegIVADTO>> GetAllAsync(BaseListRequest request);
        Task<NumeriRegIVADTO> GetByIdAsync(int id);
        Task<NumeriRegIVADTO> AddAsync(NumeriRegIVADTO dto);
        Task<NumeriRegIVADTO> UpdateAsync(NumeriRegIVADTO dto);
        Task DeleteAsync(int id);
    }
}