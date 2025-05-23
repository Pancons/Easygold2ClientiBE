using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;

namespace EasyGold.API.Services.Interfaces.GEO
{
    public interface IStatoRegioniLangService
    {
        Task<BaseListResponse<StatoRegioniLangDTO>> GetAllAsync();
        Task<StatoRegioniLangDTO> GetByIdAsync(int stridISONum, int stridID);
        Task<StatoRegioniLangDTO> AddAsync(StatoRegioniLangDTO dto);
        Task<StatoRegioniLangDTO> UpdateAsync(StatoRegioniLangDTO dto);
        Task DeleteAsync(int stridISONum, int stridID);
    }
}