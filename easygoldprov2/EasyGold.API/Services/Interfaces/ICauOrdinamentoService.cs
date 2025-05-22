using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface ICauOrdinamentoService
    {
        Task<BaseListResponse<CauOrdinamentoDTO>> GetAllAsync();
        Task<CauOrdinamentoDTO> GetByIdAsync(int id);
        Task<CauOrdinamentoDTO> AddAsync(CauOrdinamentoDTO dto);
        Task<CauOrdinamentoDTO> UpdateAsync(CauOrdinamentoDTO dto);
        Task DeleteAsync(int id);
    }
}