using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IListiniProdottoService
    {
        Task<BaseListResponse<ListiniProdottoDTO>> GetAllAsync(ListiniProdottoListRequest filter, string language);
        Task<ListiniProdottoDTO> GetByIdAsync(int id, string language);
        Task<ListiniProdottoDTO> AddAsync(ListiniProdottoDTO dto, string language);
        Task<ListiniProdottoDTO> UpdateAsync(ListiniProdottoDTO dto, string language);
        Task DeleteAsync(int id);
    }
}