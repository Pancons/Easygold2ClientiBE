using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IUtentePostazioneService
    {
        Task<BaseListResponse<UtentePostazioneDTO>> GetAllAsync(UtentePostazioneListRequest request);
        Task<UtentePostazioneDTO> GetByIdAsync(int id);
        Task<UtentePostazioneDTO> AddAsync(UtentePostazioneDTO dto);
        Task<UtentePostazioneDTO> UpdateAsync(UtentePostazioneDTO dto);
        Task DeleteAsync(int id);
    }
}
