using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Services.Implementations
{
    public class CauOrdinamentoService : ICauOrdinamentoService
    {
        private readonly ICauOrdinamentoRepository _repository;

        public CauOrdinamentoService(ICauOrdinamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CauOrdinamentoDTO>> GetAllAsync(CauOrdinamentoListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CauOrdinamentoDTO>(dtos, total);
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
            return MapToDto(entity);
        }

        public async Task<CauOrdinamentoDTO> UpdateAsync(CauOrdinamentoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Cao_IDAuto);
            if (entity == null) return null;

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
            return new CauOrdinamentoDTO
            {
                Cao_IDAuto = entity.Cao_IDAuto,
                Cao_Ordinamento = entity.Cao_Ordinamento
                // Map additional fields as necessary
            };
        }

        private DbCauOrdinamento MapToEntity(CauOrdinamentoDTO dto)
        {
            return new DbCauOrdinamento
            {
                Cao_IDAuto = dto.Cao_IDAuto,
                Cao_Ordinamento = dto.Cao_Ordinamento
                // Map additional fields as necessary
            };
        }
    }
}