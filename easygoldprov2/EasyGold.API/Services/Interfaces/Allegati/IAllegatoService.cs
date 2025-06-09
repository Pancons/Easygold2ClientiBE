using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Allegati;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Services.Interfaces.Allegati
{
    public interface IAllegatoService
    {
        Task<BaseListResponse<AllegatoDTO>> GetAllAsync();
        Task<AllegatoDTO> GetByIdAsync(int id);
        Task<AllegatoDTO> AddAsync(AllegatoDTO allegato);
        Task<AllegatoDTO> UpdateAsync(AllegatoDTO allegato);
        Task DeleteAsync(int id);
        Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath);
    }

}

