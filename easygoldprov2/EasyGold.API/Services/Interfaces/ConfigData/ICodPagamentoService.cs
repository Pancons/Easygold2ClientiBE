using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface ICodPagamentoService
    {
        Task<BaseListResponse<CodPagamentoDTO>> GetAllAsync(BaseListRequest request);
        Task<CodPagamentoDTO> GetByIdAsync(int id);
        Task<CodPagamentoDTO> AddAsync(CodPagamentoDTO dto);
        Task<CodPagamentoDTO> UpdateAsync(CodPagamentoDTO dto);
        Task DeleteAsync(int id);
    }
}