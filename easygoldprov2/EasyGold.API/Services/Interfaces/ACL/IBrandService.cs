using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Brand;
using EasyGold.Web2.Models.Cliente.Entities.Brand;


namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IBrandService
    {
        /// <summary>
        /// Restituisce una lista di brand filtrati e paginati.
        /// </summary>
        /// <param name="filter">Parametri di filtraggio e paginazione</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>Lista e totale di brand</returns>
        Task<BaseListResponse<BrandDTO>> GetAllAsync(BrandListRequest filter, string language);

        /// <summary>
        /// Restituisce un brand specificato per ID.
        /// </summary>
        /// <param name="id">ID del brand</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>Oggetto BrandDTO del brand trovato</returns>
        Task<BrandDTO> GetByIdAsync(int id, string language);

        /// <summary>
        /// Aggiunge un nuovo brand al sistema.
        /// </summary>
        /// <param name="dto">Oggetto BrandDTO con i dati del brand</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>Oggetto BrandDTO del brand aggiunto</returns>
        Task<BrandDTO> AddAsync(BrandDTO dto, string language);

        /// <summary>
        /// Aggiorna un brand esistente.
        /// </summary>
        /// <param name="dto">Oggetto BrandDTO con i dati aggiornati del brand</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>Oggetto BrandDTO del brand aggiornato</returns>
        Task<BrandDTO> UpdateAsync(BrandDTO dto, string language);

        /// <summary>
        /// Elimina un brand specificato per ID.
        /// </summary>
        /// <param name="id">ID del brand da eliminare</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}