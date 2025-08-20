using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ICodPagamentoService
    {
        Task<BaseListResponse<CodPagamentoDTO>> GetAllAsync(CodPagamentoListRequest filter, string language);
        Task<CodPagamentoDTO> GetByIdAsync(int id, string language);
        Task<CodPagamentoDTO> AddAsync(CodPagamentoDTO dto, string language);
        Task<CodPagamentoDTO> UpdateAsync(CodPagamentoDTO dto, string language);
        Task DeleteAsync(int id);
    }
}