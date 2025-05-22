using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class AliquoteIVALangService : IAliquoteIVALangService
    {
        private readonly IAliquoteIVALangRepository _repository;

        public AliquoteIVALangService(IAliquoteIVALangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<AliquoteIVALangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<AliquoteIVALangDTO>(list, list.Count);
        }

        public async Task<AliquoteIVALangDTO> GetByIdAsync(int isonum, int id)
        {
            var entity = await _repository.GetByIdAsync(isonum, id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<AliquoteIVALangDTO> AddAsync(AliquoteIVALangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<AliquoteIVALangDTO> UpdateAsync(AliquoteIVALangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Ivaid_ISONum, dto.Ivaid_ID);
            if (entity == null) return null;

            entity.Ivaid_Descrizione = dto.Ivaid_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            await _repository.DeleteAsync(isonum, id);
        }

        private AliquoteIVALangDTO MapToDto(DbAliquoteIVALang entity)
        {
            if (entity == null) return null;
            return new AliquoteIVALangDTO
            {
                Ivaid_ISONum = entity.Ivaid_ISONum,
                Ivaid_ID = entity.Ivaid_ID,
                Ivaid_Descrizione = entity.Ivaid_Descrizione
            };
        }

        private DbAliquoteIVALang MapToEntity(AliquoteIVALangDTO dto)
        {
            if (dto == null) return null;
            return new DbAliquoteIVALang
            {
                Ivaid_ISONum = dto.Ivaid_ISONum,
                Ivaid_ID = dto.Ivaid_ID,
                Ivaid_Descrizione = dto.Ivaid_Descrizione
            };
        }
    }
}