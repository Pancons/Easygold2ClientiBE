using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces
{
    public interface IDocumentiClienteService
    {
        Task<BaseListResponse<DocumentiClienteDTO>> GetAllAsync(BaseListRequest request);
        Task<DocumentiClienteDTO> GetByIdAsync(int id);
        Task<DocumentiClienteDTO> AddAsync(DocumentiClienteDTO dto);
        Task<DocumentiClienteDTO> UpdateAsync(DocumentiClienteDTO dto);
        Task DeleteAsync(int id);
    }
}