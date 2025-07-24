using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITestataPostazioniService
    {
        Task<BaseListResponse<TestataPostazioniDTO>> GetAllAsync(TestataPostazioniListRequest request);
        Task<TestataPostazioniDTO> GetByIdAsync(int id);
        Task<TestataPostazioniDTO> AddAsync(TestataPostazioniDTO dto);
        Task<TestataPostazioniDTO> UpdateAsync(TestataPostazioniDTO dto);
        Task DeleteAsync(int id);
    }
}
