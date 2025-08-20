using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IDocumentiFunzioneRepository
    {
        Task<(IEnumerable<DbDocumentiFunzione>, int total)> GetAllAsync(DocumentiFunzioneListRequest filter);
        Task<DbDocumentiFunzione> GetByIdAsync(int id);
        Task AddAsync(DbDocumentiFunzione entity);
        Task UpdateAsync(DbDocumentiFunzione entity);
        Task DeleteAsync(int id);
    }
}