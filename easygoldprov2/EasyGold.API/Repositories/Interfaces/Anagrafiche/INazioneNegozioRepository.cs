using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INazioneNegozioRepository
    {
        /// <summary>
        /// Restituisce tutte le nazioni negozio con paginazione e filtri.
        /// </summary>
        Task<(IEnumerable<DbNazioneNegozio> items, int total)> GetAllAsync(NazioneNegozioListRequest request);

        /// <summary>
        /// Restituisce una specifica nazione negozio tramite ID.
        /// </summary>
        Task<DbNazioneNegozio> GetByIdAsync(int id);

        /// <summary>
        /// Aggiunge una nuova nazione negozio.
        /// </summary>
        Task AddAsync(DbNazioneNegozio entity);

        /// <summary>
        /// Aggiorna una nazione negozio esistente.
        /// </summary>
        Task<DbNazioneNegozio> UpdateAsync(DbNazioneNegozio entity);

        /// <summary>
        /// Elimina una nazione negozio tramite ID.
        /// </summary>
        Task DeleteAsync(int id);
    }
}