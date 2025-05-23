using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.Prodotti
{
    public interface IListiniProdottoService
    {
        Task<BaseListResponse<ListiniProdottoDTO>> GetAllAsync();
        Task<ListiniProdottoDTO> GetByIdAsync(int id);
        Task<ListiniProdottoDTO> AddAsync(ListiniProdottoDTO dto);
        Task<ListiniProdottoDTO> UpdateAsync(ListiniProdottoDTO dto);
        Task DeleteAsync(int id);
    }
}