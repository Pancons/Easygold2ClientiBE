using EasyGold.API.Models.Entities.Allegati;
using Microsoft.AspNetCore.Mvc;


namespace EasyGold.API.Repositories.Interfaces.Allegati
{
    public interface IAllegatoRepository
    {
        Task<IEnumerable<DbAllegato>> GetAllAsync();
        Task<DbAllegato> GetByIdAsync(int id);
        Task AddAsync(DbAllegato allegato);
        Task UpdateAsync(DbAllegato allegato);
        Task UpdateAllAsync(int idEntita, string tipoEntita, List<DbAllegato> allegati);
        Task DeleteAsync(int id);
        Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath);
    }
}
