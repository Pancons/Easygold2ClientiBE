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

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IBrandRepository
    {
        /// <summary>
        /// Ottiene una lista paginata di brand con filtro e preferenza linguistica.
        /// </summary>
        /// <param name="filter">Filtri di ricerca e paginazione</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>Lista di brand e il conteggio totale</returns>
        Task<(IEnumerable<DbBrand>, int total)> GetAllAsync(BrandListRequest filter, string language);

        /// <summary>
        /// Ottiene un brand specifico per ID con preferenza linguistica.
        /// </summary>
        /// <param name="id">ID del brand</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns>L'entità DbBrand trovata</returns>
        Task<DbBrand> GetByIdAsync(int id, string language);

        /// <summary>
        /// Aggiunge un nuovo brand al database.
        /// </summary>
        /// <param name="entity">L'entità DbBrand da aggiungere</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns></returns>
        Task AddAsync(DbBrand entity, string language);

        /// <summary>
        /// Aggiorna un brand esistente nel database.
        /// </summary>
        /// <param name="entity">L'entità DbBrand da aggiornare</param>
        /// <param name="language">Codice ISO della lingua desiderata</param>
        /// <returns></returns>
        Task UpdateAsync(DbBrand entity, string language);

        /// <summary>
        /// Elimina un brand specifico per ID.
        /// </summary>
        /// <param name="id">ID del brand da eliminare</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}