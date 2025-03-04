using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        /*
        Task<IEnumerable<DbCliente>> GetAllAsync();
        Task<DbCliente> GetByIdAsync(int id);
        Task AddAsync(DbCliente cliente);
        Task UpdateAsync(DbCliente cliente);
        Task DeleteAsync(int id);
        */
        
        // Aggiunta della definizione del metodo GetClientiAsync
      
        Task<(IEnumerable<DbCliente> Clienti, int Total)> GetClientiAsync(
        ClienteFilter filters, int offset, int limit, string sortField, string sortOrder);

        Task AddClienteAsync(DbCliente cliente, DbDatiCliente datiCliente);

        Task UpdateClienteAsync(ClienteDettaglioDTO clienteDto);

         Task<ClienteDettaglioDTO> GetClienteByIdAsync(int id);
    }
}
