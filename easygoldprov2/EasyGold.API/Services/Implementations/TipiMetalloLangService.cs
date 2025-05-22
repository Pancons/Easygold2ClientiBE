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
    public class TipiMetalloLangService : ITipiMetalloLangService
    {
        private readonly ITipiMetalloLangRepository _repository;

        public TipiMetalloLangService(ITipiMetalloLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipiMetalloLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TipiMetalloLangDTO>(list, list.Count);
        }

        public async Task<TipiMetalloLangDTO> GetByIdAsync(int timidISONum, int timidID)
        {
            var entity = await _repository.GetByIdAsync(timidISONum, timidID);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipiMetalloLangDTO> AddAsync(TipiMetalloLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<TipiMetalloLangDTO> UpdateAsync(TipiMetalloLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Timid_ISONum, dto.Timid_ID);
            if (entity == null) return null;

            entity.Timid_Descrizione = dto.Timid_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int timidISONum, int timidID)
        {
            await _repository.DeleteAsync(timidISONum, timidID);
        }

        // --- Mapping manuale ---

        private TipiMetalloLangDTO MapToDto(DbTipiMetalloLang entity)
        {
            if (entity == null) return null;
            return new TipiMetalloLangDTO
            {
                Timid_ISONum = entity.Timid_ISONum,
                Timid_ID = entity.Timid_ID,
                Timid_Descrizione = entity.Timid_Descrizione
            };
        }

        private DbTipiMetalloLang MapToEntity(TipiMetalloLangDTO dto)
        {
            if (dto == null) return null;
            return new DbTipiMetalloLang
            {
                Timid_ISONum = dto.Timid_ISONum,
                Timid_ID = dto.Timid_ID,
                Timid_Descrizione = dto.Timid_Descrizione
            };
        }
    }
}