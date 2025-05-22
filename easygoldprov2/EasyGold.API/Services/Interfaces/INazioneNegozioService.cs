using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface INazioneNegozioService
    {
        Task<BaseListResponse<NazioneNegozioDTO>> GetAllAsync();
        Task<NazioneNegozioDTO> GetByIdAsync(int id);
        Task<NazioneNegozioDTO> AddAsync(NazioneNegozioDTO dto);
        Task<NazioneNegozioDTO> UpdateAsync(NazioneNegozioDTO dto);
        Task DeleteAsync(int id);
    }
}