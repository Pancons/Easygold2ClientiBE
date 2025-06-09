using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CausaliComuneLangService : ICausaliComuneLangService
    {
        private readonly ICausaliComuneLangRepository _repository;

        public CausaliComuneLangService(ICausaliComuneLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CausaliComuneLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CausaliComuneLangDTO>(list, list.Count);
        }

        public async Task<CausaliComuneLangDTO> GetByIdAsync(int isonum, int id)
        {
            var entity = await _repository.GetByIdAsync(isonum, id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CausaliComuneLangDTO> AddAsync(CausaliComuneLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<CausaliComuneLangDTO> UpdateAsync(CausaliComuneLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Cac_id_ISONum, dto.Cac_id_ID);
            if (entity == null) return null;

            entity.Cac_id_Descrizione = dto.Cac_id_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            await _repository.DeleteAsync(isonum, id);
        }

        private CausaliComuneLangDTO MapToDto(DbCausaliComuneLang entity)
        {
            if (entity == null) return null;
            return new CausaliComuneLangDTO
            {
                Cac_id_ISONum = entity.Cac_id_ISONum,
                Cac_id_ID = entity.Cac_id_ID,
                Cac_id_Descrizione = entity.Cac_id_Descrizione
            };
        }

        private DbCausaliComuneLang MapToEntity(CausaliComuneLangDTO dto)
        {
            if (dto == null) return null;
            return new DbCausaliComuneLang
            {
                Cac_id_ISONum = dto.Cac_id_ISONum,
                Cac_id_ID = dto.Cac_id_ID,
                Cac_id_Descrizione = dto.Cac_id_Descrizione
            };
        }
    }
}