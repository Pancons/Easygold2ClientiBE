using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class IndirizziService : IIndirizziService
    {
        private readonly IIndirizziRepository _repository;

        public IndirizziService(IIndirizziRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<IndirizziDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<IndirizziDTO>(list, list.Count);
        }

        public async Task<IndirizziDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<IndirizziDTO> AddAsync(IndirizziDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.StrIdAuto = entity.StrIdAuto;
            return dto;
        }

        public async Task<IndirizziDTO> UpdateAsync(IndirizziDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.StrIdAuto);
            if (entity == null) return null;

            entity.StrIso1 = dto.StrIso1;
            entity.StrDescrizione = dto.StrDescrizione;
            entity.StrCodLocalita = dto.StrCodLocalita;
            entity.StrCAP = dto.StrCAP;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // --- Mapping manuale ---

        private IndirizziDTO MapToDto(DbIndirizzi entity)
        {
            if (entity == null) return null;
            return new IndirizziDTO
            {
                StrIso1 = entity.StrIso1,
                StrIdAuto = entity.StrIdAuto,
                StrDescrizione = entity.StrDescrizione,
                StrCodLocalita = entity.StrCodLocalita,
                StrCAP = entity.StrCAP
            };
        }

        private DbIndirizzi MapToEntity(IndirizziDTO dto)
        {
            if (dto == null) return null;
            return new DbIndirizzi
            {
                StrIso1 = dto.StrIso1,
                StrIdAuto = dto.StrIdAuto,
                StrDescrizione = dto.StrDescrizione,
                StrCodLocalita = dto.StrCodLocalita,
                StrCAP = dto.StrCAP
            };
        }
    }
}