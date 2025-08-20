using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IIdiomiSceltiService
    {
        Task<BaseListResponse<IdiomiSceltiDTO>> GetAllAsync(IdiomiSceltiListRequest filter);
        Task<IdiomiSceltiDTO> GetByIdAsync(int id);
        Task<IdiomiSceltiDTO> AddAsync(IdiomiSceltiDTO dto);
        Task<IdiomiSceltiDTO> UpdateAsync(IdiomiSceltiDTO dto);
        Task DeleteAsync(int id);
    }
}