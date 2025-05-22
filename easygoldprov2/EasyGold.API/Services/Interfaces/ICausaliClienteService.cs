using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface ICausaliClienteService
    {
        Task<BaseListResponse<CausaliClienteDTO>> GetAllAsync();
        Task<CausaliClienteDTO> GetByIdAsync(int id);
        Task<CausaliClienteDTO> AddAsync(CausaliClienteDTO dto);
        Task<CausaliClienteDTO> UpdateAsync(CausaliClienteDTO dto);
        Task DeleteAsync(int id);
    }
}