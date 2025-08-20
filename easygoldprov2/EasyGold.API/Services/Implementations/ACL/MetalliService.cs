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
    public class MetalliService : IMetalliService
    {
        private readonly IMetalliRepository _repository;

        public MetalliService(IMetalliRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<MetalliDTO>> GetAllAsync(MetalliListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<MetalliDTO>(dtos, total);
        }

        public async Task<MetalliDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<MetalliDTO> AddAsync(MetalliDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<MetalliDTO> UpdateAsync(MetalliDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.met_IDAuto, language);
            if (entity == null) return null;

            entity.Met_Descrizione = dto.met_descrizione;
            entity.Met_Quotazione = dto.met_quotazione;
            entity.Met_TipiMetallo = dto.met_tipiMetallo;
            entity.Met_Annullato = dto.met_annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private MetalliDTO MapToDto(DbMetalli entity)
        {
            return new MetalliDTO
            {
                met_IDAuto = entity.Met_IDAuto,
                met_descrizione = entity.Met_Descrizione,
                met_quotazione = entity.Met_Quotazione,
                met_tipiMetallo = entity.Met_TipiMetallo,
                met_annullato = entity.Met_Annullato,
                Quotazioni = entity.Quotazioni.Select(q => new QuotazioneMetalliDTO
                {
                    // Mapping dei campi di DbQuotazioneMetalli
                }).ToList(),
                Tipi = entity.TipiMetallo.Select(t => new TipiMetalloDTO
                {
                    // Mapping dei campi di DbTipiMetallo
                }).ToList(),
                Traduzioni = entity.Traduzioni.Select(t => new MetalliLangDTO
                {
                    // Mapping dei campi di DbMetalliLang
                }).ToList()
            };
        }

        private DbMetalli MapToEntity(MetalliDTO dto)
        {
            return new DbMetalli
            {
                Met_IDAuto = dto.met_IDAuto,
                Met_Descrizione = dto.met_descrizione,
                Met_Quotazione = dto.met_quotazione,
                Met_TipiMetallo = dto.met_tipiMetallo,
                Met_Annullato = dto.met_annullato,
                Quotazioni = dto.Quotazioni.Select(q => new DbQuotazioneMetalli
                {
                    // Mapping dei campi di QuotazioneMetalliDTO
                }).ToList(),
                TipiMetallo = dto.Tipi.Select(t => new DbTipiMetallo
                {
                    // Mapping dei campi di TipiMetalloDTO
                }).ToList(),
                Traduzioni = dto.Traduzioni.Select(t => new DbMetalliLang
                {
                    // Mapping dei campi di MetalliLangDTO
                }).ToList()
            };
        }
    }
}