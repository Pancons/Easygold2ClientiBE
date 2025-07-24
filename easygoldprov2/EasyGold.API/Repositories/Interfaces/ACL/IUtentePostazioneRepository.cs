using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtentePostazioneRepository
    {
        Task<(IEnumerable<DbUtentePostazione> items, int total)> GetAllAsync(UtentePostazioneListRequest request);
        Task<DbUtentePostazione> GetByIdAsync(int id);
        Task AddAsync(DbUtentePostazione dto);
        Task<DbUtentePostazione> UpdateAsync(DbUtentePostazione dto);
        Task DeleteAsync(int id);
    }
}