using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Valute;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class ValuteService : IValuteService
    {
        private readonly IValuteRepository _repository;

        public ValuteService(IValuteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ValutaDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<ValutaDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ValutaDTO> AddAsync(ValutaDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<ValutaDTO> UpdateAsync(ValutaDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Val_IdAuto);
            if (entity == null) return null;

            entity.Val_Descrizione = dto.Val_Descrizione;
            entity.Val_Cambio = dto.Val_Cambio;
            entity.Val_NumDecimali = dto.Val_NumDecimali;
            entity.Val_SimboloValuta = dto.Val_SimboloValuta;
            entity.Val_SiglaValuta = dto.Val_SiglaValuta;
            entity.Val_Annullato = dto.Val_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ValutaDTO MapToDto(DbValuta entity)
        {
            return new ValutaDTO
            {
                Val_IdAuto = entity.Val_IdAuto,
                Val_Descrizione = entity.Val_Descrizione,
                Val_Cambio = entity.Val_Cambio,
                Val_NumDecimali = entity.Val_NumDecimali,
                Val_SimboloValuta = entity.Val_SimboloValuta,
                Val_SiglaValuta = entity.Val_SiglaValuta,
                Val_Annullato = entity.Val_Annullato
            };
        }

        private DbValuta MapToEntity(ValutaDTO dto)
        {
            return new DbValuta
            {
                Val_IdAuto = dto.Val_IdAuto,
                Val_Descrizione = dto.Val_Descrizione,
                Val_Cambio = dto.Val_Cambio,
                Val_NumDecimali = dto.Val_NumDecimali,
                Val_SimboloValuta = dto.Val_SimboloValuta,
                Val_SiglaValuta = dto.Val_SiglaValuta,
                Val_Annullato = dto.Val_Annullato
            };
        }
    }
}