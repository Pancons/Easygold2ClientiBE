using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.OneriRivalutazione;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class OneriRivalutazioneService : IOneriRivalutazioneService
    {
        private readonly IOneriRivalutazioneRepository _repository;

        public OneriRivalutazioneService(IOneriRivalutazioneRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OneriRivalutazioneDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<OneriRivalutazioneDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<OneriRivalutazioneDTO> AddAsync(OneriRivalutazioneDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<OneriRivalutazioneDTO> UpdateAsync(OneriRivalutazioneDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Onr_IdAuto);
            if (entity == null) return null;

            entity.Onr_Modifica = dto.Onr_Modifica;
            entity.Onr_Fee = dto.Onr_Fee;
            entity.Onr_Ordinamento = dto.Onr_Ordinamento;
            entity.Onr_Annulla = dto.Onr_Annulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private OneriRivalutazioneDTO MapToDto(DbOneriRivalutazione entity)
        {
            return new OneriRivalutazioneDTO
            {
                Onr_IdAuto = entity.Onr_IdAuto,
                Onr_Modifica = entity.Onr_Modifica,
                Onr_Fee = entity.Onr_Fee,
                Onr_Ordinamento = entity.Onr_Ordinamento,
                Onr_Annulla = entity.Onr_Annulla
            };
        }

        private DbOneriRivalutazione MapToEntity(OneriRivalutazioneDTO dto)
        {
            return new DbOneriRivalutazione
            {
                Onr_IdAuto = dto.Onr_IdAuto,
                Onr_Modifica = dto.Onr_Modifica,
                Onr_Fee = dto.Onr_Fee,
                Onr_Ordinamento = dto.Onr_Ordinamento,
                Onr_Annulla = dto.Onr_Annulla
            };
        }
    }
}