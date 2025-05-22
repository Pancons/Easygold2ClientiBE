using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IListiniProdottoLangRepository
    {
        Task<IEnumerable<DbListiniProdottoLang>> GetAllAsync();
        Task<DbListiniProdottoLang> GetByIdAsync(int lisidISONum, int lisidID);
        Task AddAsync(DbListiniProdottoLang entity);
        Task UpdateAsync(DbListiniProdottoLang entity);
        Task DeleteAsync(int lisidISONum, int lisidID);
    }
}