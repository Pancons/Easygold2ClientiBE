using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INazioneNegozioService
    {
        /// <summary>
        /// Restituisce tutte le nazioni negozio con paginazione e filtri.
        /// </summary>
        Task<BaseListResponse<NazioneNegozioDTO>> GetAllAsync(NazioneNegozioListRequest request);
        
        /// <summary>
        /// Restituisce una specifica nazione negozio tramite ID.
        /// </summary>
        Task<NazioneNegozioDTO> GetByIdAsync(int id);
        
        /// <summary>
        /// Aggiunge una nuova nazione negozio.
        /// </summary>
        Task<NazioneNegozioDTO> AddAsync(NazioneNegozioDTO dto);
        
        /// <summary>
        /// Aggiorna una nazione negozio esistente.
        /// </summary>
        Task<NazioneNegozioDTO> UpdateAsync(NazioneNegozioDTO dto);
        
        /// <summary>
        /// Elimina una nazione negozio tramite ID.
        /// </summary>
        Task DeleteAsync(int id);
    }
}