using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ConfigProdotto;

namespace EasyGold.API.Services.Interfaces.ConfigProdotto
{
    public interface IPietrePrezioseService
    {
        Task<IEnumerable<PietraPreziosaDTO>> GetAllAsync();
        Task<PietraPreziosaDTO> GetByIdAsync(int id);
        Task<PietraPreziosaDTO> AddAsync(PietraPreziosaDTO dto);
        Task<PietraPreziosaDTO> UpdateAsync(PietraPreziosaDTO dto);
        Task DeleteAsync(int id);
    }
}

