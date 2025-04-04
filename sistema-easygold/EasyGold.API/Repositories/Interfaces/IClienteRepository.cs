using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Configurazioni;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IClienteRepository
    {

        Task<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<DbModuloEasygold> Moduli, List<DbAllegato> Allegati, List<DbNegozi> Negozi, DbNazioni Nazione)>
        GetClienteByIdAsync(int id);

        Task<(IEnumerable<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<Tuple<DbModuloEasygold, DbModuloCliente>>? Moduli, DbNazioni? Nazione)> Clienti, int Total)>
            GetClientiAsync(ClienteListRequest request);

        // Aggiunta della definizione del metodo GetClientiAsync

        Task AddClienteAsync(
            DbCliente cliente,
            DbDatiCliente datiCliente,
            List<ModuloIntermedio> moduli,
            List<DbAllegato> allegati,
            List<DbNegozi> negozi);



        Task UpdateClienteAsync(
         DbCliente cliente,
         DbDatiCliente datiCliente,
         List<ModuloIntermedio> moduli,
         List<DbAllegato> allegati,
         List<DbNegozi> negozi);

        Task DeleteAsync(int id);

    }
}
