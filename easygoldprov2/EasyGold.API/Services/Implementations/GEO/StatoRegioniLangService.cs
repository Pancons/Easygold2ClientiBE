using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.API.Services.Interfaces.GEO;
using EasyGold.API.Repositories.Interfaces.GEO;

namespace EasyGold.API.Services.Implementations.GEO
{
    public class StatoRegioniLangService : IStatoRegioniLangService
    {
        private readonly IStatoRegioniLangRepository _repository;

        public StatoRegioniLangService(IStatoRegioniLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<StatoRegioniLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<StatoRegioniLangDTO>(list, list.Count);
        }

        public async Task<StatoRegioniLangDTO> GetByIdAsync(int stridISONum, int stridID)
        {
            var entity = await _repository.GetByIdAsync(stridISONum, stridID);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<StatoRegioniLangDTO> AddAsync(StatoRegioniLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<StatoRegioniLangDTO> UpdateAsync(StatoRegioniLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.StridISONum, dto.StridID);
            if (entity == null) return null;

            entity.StridDescrizione = dto.StridDescrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int stridISONum, int stridID)
        {
            await _repository.DeleteAsync(stridISONum, stridID);
        }

        // --- Mapping manuale ---

        private StatoRegioniLangDTO MapToDto(DbStatoRegioniLang entity)
        {
            if (entity == null) return null;
            return new StatoRegioniLangDTO
            {
                StridISONum = entity.StridISONum,
                StridID = entity.StridID,
                StridDescrizione = entity.StridDescrizione
            };
        }

        private DbStatoRegioniLang MapToEntity(StatoRegioniLangDTO dto)
        {
            if (dto == null) return null;
            return new DbStatoRegioniLang
            {
                StridISONum = dto.StridISONum,
                StridID = dto.StridID,
                StridDescrizione = dto.StridDescrizione
            };
        }
    }
}