using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Moduli;

namespace EasyGold.API.Services.Interfaces.ConfigProgramma
{
    public interface IModuloService
    {

        Task<BaseListResponse<ModuloDTO>> GetAllAsync();
        Task<ModuloDTO> GetByIdAsync(int id);
        Task AddAsync(ModuloDTO moduloDto);
        Task UpdateAsync(ModuloDTO moduloDto);
        Task DeleteAsync(int id);
        /*
                Task<ModuloDTO> GetByIdAsync(int id);
                Task AddAsync(ModuloDTO moduloDto);
                Task UpdateAsync(ModuloDTO moduloDto);
                Task DeleteAsync(int id);
                */
    }
}