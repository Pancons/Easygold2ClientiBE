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
    public class CauOrdinamentoService : ICauOrdinamentoService
    {
        private readonly ICauOrdinamentoRepository _repository;

        public CauOrdinamentoService(ICauOrdinamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CauOrdinamentoDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CauOrdinamentoDTO>(list, list.Count);
        }

        public async Task<CauOrdinamentoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CauOrdinamentoDTO> AddAsync(CauOrdinamentoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Cao_IDAuto = entity.Cao_IDAuto;
            return dto;
        }

        public async Task<CauOrdinamentoDTO> UpdateAsync(CauOrdinamentoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Cao_IDAuto);
            if (entity == null) return null;

            entity.Cao_ID = dto.Cao_ID;
            entity.Cao_Ordinamento = dto.Cao_Ordinamento;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CauOrdinamentoDTO MapToDto(DbCauOrdinamento entity)
        {
            if (entity == null) return null;
            return new CauOrdinamentoDTO
            {
                Cao_IDAuto = entity.Cao_IDAuto,
                Cao_ID = entity.Cao_ID,
                Cao_Ordinamento = entity.Cao_Ordinamento
            };
        }

        private DbCauOrdinamento MapToEntity(CauOrdinamentoDTO dto)
        {
            if (dto == null) return null;
            return new DbCauOrdinamento
            {
                Cao_IDAuto = dto.Cao_IDAuto,
                Cao_ID = dto.Cao_ID,
                Cao_Ordinamento = dto.Cao_Ordinamento
            };
        }
    }
}