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
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class BrandCatService : IBrandCatService
    {
        private readonly IBrandCatRepository _repository;

        public BrandCatService(IBrandCatRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<BrandCatDTO>> GetAllAsync(BrandCatListRequest request)
        {
            var (categories, total) = await _repository.GetAllAsync(request);
            var list = categories.Select(MapToDto).ToList();
            return new BaseListResponse<BrandCatDTO>(list, total);
        }

        public async Task<BrandCatDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<BrandCatDTO> AddAsync(BrandCatDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<BrandCatDTO> UpdateAsync(BrandCatDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Brc_IDAuto);
            if (entity == null) return null;

            // Aggiorna i campi dell'entità
            entity.Brc_IDBrand = dto.Brc_IDBrand;
            entity.Brc_IDCategoria = dto.Brc_IDCategoria;
            entity.Brc_Annullato = dto.Brc_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private BrandCatDTO MapToDto(DbBrandCat entity)
        {
            return new BrandCatDTO
            {
                Brc_IDAuto = entity.Brc_IDAuto,
                Brc_IDBrand = entity.Brc_IDBrand,
                Brc_IDCategoria = entity.Brc_IDCategoria,
                Brc_Annullato = entity.Brc_Annullato
            };
        }

        private DbBrandCat MapToEntity(BrandCatDTO dto)
        {
            return new DbBrandCat
            {
                Brc_IDAuto = dto.Brc_IDAuto,
                Brc_IDBrand = dto.Brc_IDBrand,
                Brc_IDCategoria = dto.Brc_IDCategoria,
                Brc_Annullato = dto.Brc_Annullato
            };
        }
    }
}