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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class TipiMetalloService : ITipiMetalloService
    {
        private readonly ITipiMetalloRepository _repository;

        public TipiMetalloService(ITipiMetalloRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipiMetalloDTO>> GetAllAsync(TipiMetalloListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<TipiMetalloDTO>(dtos, total);
        }

        public async Task<TipiMetalloDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipiMetalloDTO> AddAsync(TipiMetalloDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<TipiMetalloDTO> UpdateAsync(TipiMetalloDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Tim_IDAuto, language);
            if (entity == null) return null;

            entity.Tim_ID = dto.Tim_ID;
            entity.Tim_Descrizione = dto.Tim_Descrizione;
            entity.Tim_Annullato = dto.Tim_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TipiMetalloDTO MapToDto(DbTipiMetallo entity)
        {
            return new TipiMetalloDTO
            {
                Tim_IDAuto = entity.Tim_IDAuto,
                Tim_ID = entity.Tim_ID,
                Tim_Descrizione = entity.Tim_Descrizione,
                Tim_Annullato = entity.Tim_Annullato,
                // Map language-specific fields from TipiMetalloLang if needed
            };
        }

        private DbTipiMetallo MapToEntity(TipiMetalloDTO dto)
        {
            return new DbTipiMetallo
            {
                Tim_IDAuto = dto.Tim_IDAuto,
                Tim_ID = dto.Tim_ID,
                Tim_Descrizione = dto.Tim_Descrizione,
                Tim_Annullato = dto.Tim_Annullato,
                // Map any necessary relationships
            };
        }
    }
}