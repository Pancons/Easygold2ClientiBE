
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Models.CodPagamento;
using EasyGold.API.Models.Entities;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CodPagamentoService : ICodPagamentoService
    {
        private readonly ICodPagamentoRepository _repository;

        public CodPagamentoService(ICodPagamentoRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<CondizionePagamentoDTO>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }























        public async Task<CondizionePagamentoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return entity == null ? null : MapToDto(entity);
        }


        public async Task<CondizionePagamentoDTO> AddAsync(CondizionePagamentoDTO dto)
        {

            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);

            return MapToDto(entity);
        }


        public async Task<CondizionePagamentoDTO> UpdateAsync(CondizionePagamentoDTO dto)
        {

            var entity = await _repository.GetByIdAsync(dto.Cpa_IdAuto);
            if (entity == null) return null;

            entity.Cpa_Descrizione = dto.Cpa_Descrizione;
            entity.Cpa_PartenzaMese = dto.Cpa_PartenzaMese;
            entity.Cpa_NumMesi = dto.Cpa_NumMesi;
            entity.Cpa_MeseCommerciale = dto.Cpa_MeseCommerciale;
            entity.Cpa_Annullato = dto.Cpa_Annullato;

            await _repository.UpdateAsync(entity);

            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        private CondizionePagamentoDTO MapToDto(DbCondizionePagamento entity)
        {
            return new CondizionePagamentoDTO
            {
                Cpa_IdAuto = entity.Cpa_IdAuto,
                Cpa_Descrizione = entity.Cpa_Descrizione,
                Cpa_PartenzaMese = entity.Cpa_PartenzaMese,
                Cpa_NumMesi = entity.Cpa_NumMesi,
                Cpa_MeseCommerciale = entity.Cpa_MeseCommerciale,
                Cpa_Annullato = entity.Cpa_Annullato
            };
        }

        private DbCondizionePagamento MapToEntity(CondizionePagamentoDTO dto)
        {
            return new DbCondizionePagamento
            {
                Cpa_IdAuto = dto.Cpa_IdAuto,
                Cpa_Descrizione = dto.Cpa_Descrizione,
                Cpa_PartenzaMese = dto.Cpa_PartenzaMese,
                Cpa_NumMesi = dto.Cpa_NumMesi,
                Cpa_MeseCommerciale = dto.Cpa_MeseCommerciale,
                Cpa_Annullato = dto.Cpa_Annullato
            };
        }
    }
}
