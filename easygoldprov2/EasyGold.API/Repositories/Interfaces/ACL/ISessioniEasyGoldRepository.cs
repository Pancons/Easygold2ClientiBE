using EasyGold.Web2.Models.Cliente.Entities.ACL;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ISessioniEasyGoldRepository
    {
        /// <summary>
        /// Recupera una lista di postazioni fiscali con supporto a filtri e paginazione.
        /// </summary>
        /// <param name="request">Richiesta con criteri di filtro e paginazione.</param>
        /// <returns>Una tupla contenente la lista delle postazioni e il totale.</returns>
        Task<(IEnumerable<DbSessioniEasyGold> items, int total)> GetAllAsync(SessioniEasyGoldListRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">L'ID della postazione fiscale da recuperare.</param>
        /// <returns>Il DTO della postazione fiscale.</returns>
        Task<DbSessioniEasyGold> GetByIdAsync(int id);

        /// <summary>
        /// Aggiunge una nuova postazione fiscale nel sistema.
        /// </summary>
        /// <param name="dto">Il DTO della postazione fiscale da aggiungere.</param>
        Task AddAsync(DbSessioniEasyGold dto);

        /// <summary>
        /// Aggiorna una postazione fiscale esistente.
        /// </summary>
        /// <param name="dto">Il DTO della postazione fiscale da aggiornare.</param>
        /// <returns>Il DTO aggiornato della postazione fiscale.</returns>
        Task<DbSessioniEasyGold> UpdateAsync(DbSessioniEasyGold dto);

        /// <summary>
        /// Elimina una postazione fiscale tramite ID.
        /// </summary>
        /// <param name="id">L'ID della postazione fiscale da eliminare.</param>
        Task DeleteAsync(int id);
    }
}