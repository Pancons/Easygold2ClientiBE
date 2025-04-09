using EasyGold.API.Models.StatiCliente;

namespace EasyGold.API.Services.Interfaces
{
    public interface IStatiClienteService
    {
       
        Task<IEnumerable<StatoClienteDTO>> GetAllAsync(StatoClienteListRequest request);
        Task<StatoClienteDTO> GetByIdAsync(int id);
    }
}