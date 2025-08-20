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
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository _repository;

        public CategorieService(ICategorieRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CategorieDTO>> GetAllAsync(CategorieListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<CategorieDTO>(dtos, total);
        }

        public async Task<CategorieDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CategorieDTO> AddAsync(CategorieDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CategorieDTO> UpdateAsync(CategorieDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Cat_IDAuto, language);
            if (entity == null) return null;

            entity.Cat_DescCategoria = dto.Cat_DescCategoria;
            entity.Cat_IDPadre = dto.Cat_IDPadre;
            entity.Cat_Annulla = dto.Cat_Annulla;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CategorieDTO MapToDto(DbCategorie entity)
        {
            return new CategorieDTO
            {
                Cat_IDAuto = entity.Cat_IDAuto,
                Cat_IDPadre = entity.Cat_IDPadre,
                Cat_DescCategoria = entity.Cat_DescCategoria,
                Cat_Annulla = entity.Cat_Annulla,
                CategorieLang = entity.CategorieLang.Select(lang => new CategorieLangDTO
                {
                    Catid_ISONum = lang.Catid_ISONum,
                    Catid_ID = lang.Catid_ID,
                    Catid_DescCategoria = lang.Catid_DescCategoria
                }).ToList()
            };
        }

        private DbCategorie MapToEntity(CategorieDTO dto)
        {
            return new DbCategorie
            {
                Cat_IDAuto = dto.Cat_IDAuto,
                Cat_IDPadre = dto.Cat_IDPadre,
                Cat_DescCategoria = dto.Cat_DescCategoria,
                Cat_Annulla = dto.Cat_Annulla
                // Assume a separate function handles the mapping of language-specific fields
            };
        }
    }
}