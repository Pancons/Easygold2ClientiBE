 using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models.Variabili;

namespace EasyGold.API.Services.Interfaces
{
    public interface IValoriTabelleService
    {
        Task<BaseListResponse<ValoriTabelleDTO>> FindAsync(string lstItemType);
        Task<ValoriTabelleDTO> SaveAsync(ValoriTabelleDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
 
 
 