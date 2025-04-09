using EasyGold.API.Models.Entities;
using EasyGold.API.Models.StatiCliente;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IStatoClientiRepository
    {
        Task<IEnumerable<DbStatoCliente>> GetAllAsync(StatoClienteListRequest request);
        Task<DbStatoCliente> GetByIdAsync(int id);
    }
}
