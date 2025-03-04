using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Interfaces
{
    public interface IClienteService
    {
        /*
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDettaglioDTO> GetByIdAsync(int id);
        Task AddAsync(ClienteDettaglioDTO clienteDettaglioDto);
        Task UpdateAsync(ClienteDettaglioDTO clienteDettaglioDto);
        Task DeleteAsync(int id);
        */
        Task<ClienteListResult> GetClientiListAsync(ClienteListRequest request);
        Task<ClienteDettaglioDTO> CreateClienteAsync(ClienteDettaglioDTO clienteDto);
        Task<ClienteDettaglioDTO> UpdateClienteAsync(int id, ClienteDettaglioDTO clienteDto);
        Task<ClienteDettaglioDTO> GetByIdAsync(int id);

    }
}
