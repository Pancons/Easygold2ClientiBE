using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.RegIVA;

namespace EasyGold.API.Services.Interfaces
{
    public interface IRegistroIVAService
    {
        Task<BaseListResponse<RegistroIVADTO>> GetAllAsync(BaseListRequest request);
        Task<RegistroIVADTO> GetByIdAsync(int id);
        Task<RegistroIVADTO> AddAsync(RegistroIVADTO dto);
        Task<RegistroIVADTO> UpdateAsync(RegistroIVADTO dto);
        Task DeleteAsync(int id);
    }
}