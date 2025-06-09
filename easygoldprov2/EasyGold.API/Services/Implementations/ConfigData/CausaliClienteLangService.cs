using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CausaliClienteLangService : ICausaliClienteLangService
    {
        private readonly ICausaliClienteLangRepository _repository;

        public CausaliClienteLangService(ICausaliClienteLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CausaliClienteLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CausaliClienteLangDTO>(list, list.Count);
        }

        public async Task<CausaliClienteLangDTO> GetByIdAsync(int isonum, int id)
        {
            var entity = await _repository.GetByIdAsync(isonum, id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CausaliClienteLangDTO> AddAsync(CausaliClienteLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<CausaliClienteLangDTO> UpdateAsync(CausaliClienteLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Cal_id_ISONum, dto.Cal_id_ID);
            if (entity == null) return null;

            entity.Cal_id_Descrizione = dto.Cal_id_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            await _repository.DeleteAsync(isonum, id);
        }

        private CausaliClienteLangDTO MapToDto(DbCausaliClienteLang entity)
        {
            if (entity == null) return null;
            return new CausaliClienteLangDTO
            {
                Cal_id_ISONum = entity.Cal_id_ISONum,
                Cal_id_ID = entity.Cal_id_ID,
                Cal_id_Descrizione = entity.Cal_id_Descrizione
            };
        }

        private DbCausaliClienteLang MapToEntity(CausaliClienteLangDTO dto)
        {
            if (dto == null) return null;
            return new DbCausaliClienteLang
            {
                Cal_id_ISONum = dto.Cal_id_ISONum,
                Cal_id_ID = dto.Cal_id_ID,
                Cal_id_Descrizione = dto.Cal_id_Descrizione
            };
        }
    }
}
