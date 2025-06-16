using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ConfigProdotto;

namespace EasyGold.API.Services.Interfaces.ConfigProdotto
{
    public interface ITipoSKUService
    {
        Task<IEnumerable<TipoSKUDTO>> GetAllAsync();
        Task<TipoSKUDTO> GetByIdAsync(int id);
        Task<TipoSKUDTO> AddAsync(TipoSKUDTO dto);
        Task<TipoSKUDTO> UpdateAsync(TipoSKUDTO dto);
        Task DeleteAsync(int id);
    }
}

