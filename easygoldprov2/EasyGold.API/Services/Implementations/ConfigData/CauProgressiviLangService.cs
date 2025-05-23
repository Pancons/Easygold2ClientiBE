using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CauProgressiviLangService : ICauProgressiviLangService
    {
        private readonly ICauProgressiviLangRepository _repository;

        public CauProgressiviLangService(ICauProgressiviLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CauProgressiviLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CauProgressiviLangDTO>(list, list.Count);
        }

        public async Task<CauProgressiviLangDTO> GetByIdAsync(int isonum, int id)
        {
            var entity = await _repository.GetByIdAsync(isonum, id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CauProgressiviLangDTO> AddAsync(CauProgressiviLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<CauProgressiviLangDTO> UpdateAsync(CauProgressiviLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Prcid_ISONum, dto.Prcid_ID);
            if (entity == null) return null;

            entity.Prcid_Descrizione = dto.Prcid_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            await _repository.DeleteAsync(isonum, id);
        }

        private CauProgressiviLangDTO MapToDto(DbCauProgressiviLang entity)
        {
            if (entity == null) return null;
            return new CauProgressiviLangDTO
            {
                Prcid_ISONum = entity.Prcid_ISONum,
                Prcid_ID = entity.Prcid_ID,
                Prcid_Descrizione = entity.Prcid_Descrizione
            };
        }

        private DbCauProgressiviLang MapToEntity(CauProgressiviLangDTO dto)
        {
            if (dto == null) return null;
            return new DbCauProgressiviLang
            {
                Prcid_ISONum = dto.Prcid_ISONum,
                Prcid_ID = dto.Prcid_ID,
                Prcid_Descrizione = dto.Prcid_Descrizione
            };
        }
    }
}