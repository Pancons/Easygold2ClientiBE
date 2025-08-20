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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<BrandDTO>> GetAllAsync(BrandListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<BrandDTO>(dtos, total);
        }

        public async Task<BrandDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<BrandDTO> AddAsync(BrandDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<BrandDTO> UpdateAsync(BrandDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Brd_IDAuto, language);
            if (entity == null) return null;

            // Aggiorna i campi dell'entità
            entity.Brd_Brand = dto.Brd_Brand;
            entity.Brd_Annulla = dto.Brd_Annulla;
            // Aggiorna le lingue e le categorie associate
            entity.BrandLang = dto.Lingue.Select(MapToEntityLang).ToList();
            entity.BrandCat = dto.Categorie.Select(MapToEntityCat).ToList();

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private BrandDTO MapToDto(DbBrand entity)
        {
            return new BrandDTO
            {
                Brd_IDAuto = entity.Brd_IDAuto,
                Brd_Brand = entity.Brd_Brand,
                Brd_Annulla = entity.Brd_Annulla,
                Lingue = entity.BrandLang.Select(lang => new BrandLangDTO
                {
                    BrdId_ISONum = lang.BrdId_ISONum,
                    BrdId_ID = lang.BrdId_ID,
                    BrdId_Brand = lang.BrdId_Brand
                }).ToList(),
                Categorie = entity.BrandCat.Select(cat => new BrandCatDTO
                {
                    Brc_IDAuto = cat.Brc_IDAuto,
                    Brc_IDBrand = cat.Brc_IDBrand,
                    Brc_IDCategoria = cat.Brc_IDCategoria,
                    Brc_Annullato = cat.Brc_Annullato
                }).ToList()
            };
        }

        private DbBrand MapToEntity(BrandDTO dto)
        {
            return new DbBrand
            {
                Brd_IDAuto = dto.Brd_IDAuto,
                Brd_Brand = dto.Brd_Brand,
                Brd_Annulla = dto.Brd_Annulla,
                BrandLang = dto.Lingue.Select(lang => new DbBrandLang
                {
                    BrdId_ISONum = lang.BrdId_ISONum,
                    BrdId_ID = lang.BrdId_ID,
                    BrdId_Brand = lang.BrdId_Brand
                }).ToList(),
                BrandCat = dto.Categorie.Select(cat => new DbBrandCat
                {
                    Brc_IDAuto = cat.Brc_IDAuto,
                    Brc_IDBrand = cat.Brc_IDBrand,
                    Brc_IDCategoria = cat.Brc_IDCategoria,
                    Brc_Annullato = cat.Brc_Annullato
                }).ToList()
            };
        }

        private DbBrandLang MapToEntityLang(BrandLangDTO dto)
        {
            return new DbBrandLang
            {
                BrdId_ISONum = dto.BrdId_ISONum,
                BrdId_ID = dto.BrdId_ID,
                BrdId_Brand = dto.BrdId_Brand
            };
        }

        private DbBrandCat MapToEntityCat(BrandCatDTO dto)
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