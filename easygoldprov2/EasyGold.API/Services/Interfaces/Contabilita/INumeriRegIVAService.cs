using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Contabilita;

namespace EasyGold.API.Services.Interfaces.Contabilita
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