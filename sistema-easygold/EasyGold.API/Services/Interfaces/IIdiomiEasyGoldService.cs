using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface IIdiomiEasyGoldService
    {
        Task<BaseListResponse<IdiomiEasyGoldDTO>> GetAllAsync(IdiomiEasyGoldListRequest filter);
        Task<IdiomiEasyGoldDTO> GetByIdAsync(int id);
        Task<IdiomiEasyGoldDTO> AddAsync(IdiomiEasyGoldDTO dto);
        Task<IdiomiEasyGoldDTO> UpdateAsync(IdiomiEasyGoldDTO dto);
        Task DeleteAsync(int id);
    }
}