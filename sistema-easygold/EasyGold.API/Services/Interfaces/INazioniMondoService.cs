using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;


namespace EasyGold.API.Services.Interfaces
{
    public interface INazioniMondoService
    {
        Task<BaseListResponse<NazioniMondoDTO>> GetAllAsync(NazioniMondoListRequest filter, string language);
        Task<NazioniMondoDTO> GetByIdAsync(int id, string language);
        Task<NazioniMondoDTO> AddAsync(NazioniMondoDTO dto, string language);
        Task<NazioniMondoDTO> UpdateAsync(NazioniMondoDTO dto, string language);
        Task DeleteAsync(int id);
    }
}