using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITagProdottiService
    {
        Task<BaseListResponse<TagProdottiDTO>> GetAllAsync(TagProdottiListRequest filter, string language);
        Task<TagProdottiDTO> GetByIdAsync(int id, string language);
        Task<TagProdottiDTO> AddAsync(TagProdottiDTO dto, string language);
        Task<TagProdottiDTO> UpdateAsync(TagProdottiDTO dto, string language);
        Task DeleteAsync(int id);
    }
}