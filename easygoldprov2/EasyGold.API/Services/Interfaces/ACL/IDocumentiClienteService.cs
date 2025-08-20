using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IDocumentiClienteService
    {
        Task<BaseListResponse<DocumentiClienteDTO>> GetAllAsync(DocumentiClienteListRequest request);
        Task<DocumentiClienteDTO> GetByIdAsync(int id);
        Task<DocumentiClienteDTO> AddAsync(DocumentiClienteDTO dto);
        Task<DocumentiClienteDTO> UpdateAsync(DocumentiClienteDTO dto);
        Task DeleteAsync(int id);
    }
}