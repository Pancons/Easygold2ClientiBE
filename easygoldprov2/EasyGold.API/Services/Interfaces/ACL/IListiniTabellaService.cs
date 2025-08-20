using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IListiniTabellaService
    {
        Task<BaseListResponse<ListiniTabellaDTO>> GetAllAsync(ListiniTabellaListRequest filter, string language);
        Task<ListiniTabellaDTO> GetByIdAsync(int id, string language);
        Task<ListiniTabellaDTO> AddAsync(ListiniTabellaDTO dto, string language);
        Task<ListiniTabellaDTO> UpdateAsync(ListiniTabellaDTO dto, string language);
        Task DeleteAsync(int id);
    }
}