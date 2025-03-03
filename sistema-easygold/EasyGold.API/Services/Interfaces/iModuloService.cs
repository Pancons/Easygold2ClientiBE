using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Clients;


namespace EasyGold.API.Services.Interfaces
{
    public interface IModuloService
    {
        Task<IEnumerable<ModuloDTO>> GetAllAsync();
/*
        Task<ModuloDTO> GetByIdAsync(int id);
        Task AddAsync(ModuloDTO moduloDto);
        Task UpdateAsync(ModuloDTO moduloDto);
        Task DeleteAsync(int id);
        */
    }
}