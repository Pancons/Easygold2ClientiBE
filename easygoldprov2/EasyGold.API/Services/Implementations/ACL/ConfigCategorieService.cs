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
using EasyGold.Web2.Models.Cliente.CategorieProdotto;
using EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class ConfigCategorieService : IConfigCategorieService
    {
        private readonly IConfigCategorieRepository _repository;

        public ConfigCategorieService(IConfigCategorieRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ConfigCategorieDTO>> GetAllAsync(ConfigCategorieListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var list = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<ConfigCategorieDTO>(list, total);
        }

        public async Task<ConfigCategorieDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ConfigCategorieDTO> AddAsync(ConfigCategorieDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<ConfigCategorieDTO> UpdateAsync(ConfigCategorieDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Coc_IDAuto);
            if (entity == null) return null;

            entity.Coc_IDBrand = dto.Coc_IDBrand;
            entity.Coc_IDTipoProdotto = dto.Coc_IDTipoProdotto;
            entity.Coc_IDTipoAcquisto = dto.Coc_IDTipoAcquisto;
            entity.Coc_IDTipoManifattura = dto.Coc_IDTipoManifattura;
            entity.Coc_IDTipoVendita = dto.Coc_IDTipoVendita;
            entity.Coc_PietrePreziose = dto.Coc_PietrePreziose;
            entity.Coc_Sottocodice = dto.Coc_Sottocodice;
            entity.Coc_PesoMedio = dto.Coc_PesoMedio;
            entity.Coc_Serie = dto.Coc_Serie;
            entity.Coc_IDSku = dto.Coc_IDSku;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ConfigCategorieDTO MapToDto(DbConfigCategorie entity)
        {
            return new ConfigCategorieDTO
            {
                Coc_IDAuto = entity.Coc_IDAuto,
                Coc_IDBrand = entity.Coc_IDBrand,
                Coc_IDTipoProdotto = entity.Coc_IDTipoProdotto,
                Coc_IDTipoAcquisto = entity.Coc_IDTipoAcquisto,
                Coc_IDTipoManifattura = entity.Coc_IDTipoManifattura,
                Coc_IDTipoVendita = entity.Coc_IDTipoVendita,
                Coc_PietrePreziose = entity.Coc_PietrePreziose,
                Coc_Sottocodice = entity.Coc_Sottocodice,
                Coc_PesoMedio = entity.Coc_PesoMedio,
                Coc_Serie = entity.Coc_Serie,
                Coc_IDSku = entity.Coc_IDSku
            };
        }

        private DbConfigCategorie MapToEntity(ConfigCategorieDTO dto)
        {
            return new DbConfigCategorie
            {
                Coc_IDAuto = dto.Coc_IDAuto,
                Coc_IDBrand = dto.Coc_IDBrand,
                Coc_IDTipoProdotto = dto.Coc_IDTipoProdotto,
                Coc_IDTipoAcquisto = dto.Coc_IDTipoAcquisto,
                Coc_IDTipoManifattura = dto.Coc_IDTipoManifattura,
                Coc_IDTipoVendita = dto.Coc_IDTipoVendita,
                Coc_PietrePreziose = dto.Coc_PietrePreziose,
                Coc_Sottocodice = dto.Coc_Sottocodice,
                Coc_PesoMedio = dto.Coc_PesoMedio,
                Coc_Serie = dto.Coc_Serie,
                Coc_IDSku = dto.Coc_IDSku
            };
        }
    }
}