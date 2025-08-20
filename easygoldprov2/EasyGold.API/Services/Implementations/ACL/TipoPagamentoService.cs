using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class TipoPagamentoService : ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _repository;

        public TipoPagamentoService(ITipoPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipoPagamentoDTO>> GetAllAsync(TipoPagamentoListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TipoPagamentoDTO>(dtos, total);
        }

        public async Task<TipoPagamentoDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoPagamentoDTO> AddAsync(TipoPagamentoDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<TipoPagamentoDTO> UpdateAsync(TipoPagamentoDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Tpg_IDAuto, language);
            if (entity == null) return null;

            entity.Tpg_Descrizione = dto.Tpg_Descrizione;
            entity.Tpg_Tipo = dto.Tpg_Tipo;
            entity.Tpg_Ordinamento = dto.Tpg_Ordinamento;
            entity.Tpg_Annulla = dto.Tpg_Annulla;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TipoPagamentoDTO MapToDto(DbTipoPagamento entity)
        {
            return new TipoPagamentoDTO
            {
                Tpg_IDAuto = entity.Tpg_IDAuto,
                Tpg_Descrizione = entity.Tpg_Descrizione,
                Tpg_Tipo = entity.Tpg_Tipo,
                Tpg_Ordinamento = entity.Tpg_Ordinamento,
                Tpg_Annulla = entity.Tpg_Annulla,
                // Gestire i campi specifici per la lingua da TipoPagamentoLang
            };
        }

        private DbTipoPagamento MapToEntity(TipoPagamentoDTO dto)
        {
            return new DbTipoPagamento
            {
                Tpg_IDAuto = dto.Tpg_IDAuto,
                Tpg_Descrizione = dto.Tpg_Descrizione,
                Tpg_Tipo = dto.Tpg_Tipo,
                Tpg_Ordinamento = dto.Tpg_Ordinamento,
                Tpg_Annulla = dto.Tpg_Annulla,
                // Gestire eventuali relazioni necessarie
            };
        }
    }
}