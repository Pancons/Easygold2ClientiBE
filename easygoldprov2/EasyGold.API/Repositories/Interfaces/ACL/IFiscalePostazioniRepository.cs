using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IFiscalePostazioniRepository
    {   
        Task<(IEnumerable<DbFiscalePostazioni> items, int total)> GetAllAsync(FiscalePostazioniListRequest request);
        Task<DbFiscalePostazioni> GetByIdAsync(int id);
        Task AddAsync(DbFiscalePostazioni dto);
        Task<DbFiscalePostazioni> UpdateAsync(DbFiscalePostazioni dto);
        Task DeleteAsync(int id);
    }
}