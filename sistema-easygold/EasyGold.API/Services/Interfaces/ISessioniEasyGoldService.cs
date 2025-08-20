using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Services.Interfaces
{
    public interface ISessioniEasyGoldService
    {
        /// <summary>
        /// Restituisce una lista di postazioni fiscali paginata e filtrata.
        /// </summary>
        /// <param name="request">Richiesta contenente filtri e parametri di paginazione.</param>
        /// <returns>Una risposta contenente la lista e il totale delle postazioni.</returns>
        Task<BaseListResponse<SessioniEasyGoldDTO>> GetAllAsync(SessioniEasyGoldListRequest request);

        /// <summary>
        /// Restituisce una postazione fiscale specifica tramite ID.
        /// </summary>
        /// <param name="id">L'ID della postazione fiscale da ottenere.</param>
        /// <returns>Il DTO della postazione fiscale.</returns>
        Task<SessioniEasyGoldDTO> GetByIdAsync(int id);

        /// <summary>
        /// Aggiunge una nuova postazione fiscale.
        /// </summary>
        /// <param name="dto">Il DTO della postazione fiscale da aggiungere.</param>
        /// <returns>Il DTO della postazione fiscale appena creata.</returns>
        Task<SessioniEasyGoldDTO> AddAsync(SessioniEasyGoldDTO dto);

        /// <summary>
        /// Aggiorna una postazione fiscale esistente.
        /// </summary>
        /// <param name="dto">Il DTO della postazione fiscale da aggiornare.</param>
        /// <returns>Il DTO della postazione fiscale aggiornata.</returns>
        Task<SessioniEasyGoldDTO> UpdateAsync(SessioniEasyGoldDTO dto);

        /// <summary>
        /// Elimina una postazione fiscale tramite ID.
        /// </summary>
        /// <param name="id">L'ID della postazione fiscale da eliminare.</param>
        Task DeleteAsync(int id);


        Task EndSessionOnTokenExpiryAsync(int userId);

        Task EndSessionAsync(int sessionId);


    }
}