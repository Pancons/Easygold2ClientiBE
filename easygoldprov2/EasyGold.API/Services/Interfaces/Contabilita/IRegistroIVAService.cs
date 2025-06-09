using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Contabilita;

namespace EasyGold.API.Services.Interfaces.Contabilita
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