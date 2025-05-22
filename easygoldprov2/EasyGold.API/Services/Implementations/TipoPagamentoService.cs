using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.TipoPagamento;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class TipoPagamentoService : ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _repository;

        public TipoPagamentoService(ITipoPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoPagamentoDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<TipoPagamentoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoPagamentoDTO> AddAsync(TipoPagamentoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoPagamentoDTO> UpdateAsync(TipoPagamentoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tip_IdAuto);
            if (entity == null) return null;

            entity.Tip_Descrizione = dto.Tip_Descrizione;
            entity.Tip_Banca = dto.Tip_Banca;
            entity.Tip_Annullato = dto.Tip_Annullato;

            await _repository.UpdateAsync(entity);
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
                Tip_IdAuto = entity.Tip_IdAuto,
                Tip_Descrizione = entity.Tip_Descrizione,
                Tip_Banca = entity.Tip_Banca,
                Tip_Annullato = entity.Tip_Annullato
            };
        }

        private DbTipoPagamento MapToEntity(TipoPagamentoDTO dto)
        {
            return new DbTipoPagamento
            {
                Tip_IdAuto = dto.Tip_IdAuto,
                Tip_Descrizione = dto.Tip_Descrizione,
                Tip_Banca = dto.Tip_Banca,
                Tip_Annullato = dto.Tip_Annullato
            };
        }
    }
}