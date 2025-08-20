using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IProvinceRepository
    {
        Task<(IEnumerable<DbProvince>, int total)> GetAllAsync(ProvinceListRequest filter, string language);
        Task<DbProvince> GetByIdAsync(int id, string language);
        Task AddAsync(DbProvince entity, string language);
        Task UpdateAsync(DbProvince entity, string language);
        Task DeleteAsync(int id);
    }
}