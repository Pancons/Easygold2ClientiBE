using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Allegati;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Services.Interfaces
{
    public interface IAllegatoService
    {
        Task<IEnumerable<AllegatoDTO>> GetAllAsync();
        Task<AllegatoDTO> GetByIdAsync(int id);
        Task<AllegatoDTO> AddAsync(AllegatoDTO allegato);
        Task<AllegatoDTO> UpdateAsync(AllegatoDTO allegato);
        Task DeleteAsync(int id);
        Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath);
    }

}

