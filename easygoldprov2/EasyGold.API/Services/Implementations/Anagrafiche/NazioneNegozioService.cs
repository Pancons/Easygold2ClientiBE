using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.API.Services.Interfaces.Anagrafiche;

namespace EasyGold.API.Services.Implementations.Anagrafiche
{
    public class NazioneNegozioService : INazioneNegozioService
    {
        private readonly INazioneNegozioRepository _repository;

        public NazioneNegozioService(INazioneNegozioRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NazioneNegozioDTO>> GetAllAsync(NazioneNegozioListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NazioneNegozioDTO>(items, total);
        }

        public async Task<NazioneNegozioDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NazioneNegozioDTO> AddAsync(NazioneNegozioDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<NazioneNegozioDTO> UpdateAsync(NazioneNegozioDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Nne_IDAuto);
            if (entity == null) return null;
            
            // Aggiornare campi specifici
            entity.Nne_IDNegozio = dto.Nne_IDNegozio;
            entity.Nne_IDTipoCampo = dto.Nne_IDTipoCampo;
            entity.Nne_Valore = dto.Nne_Valore;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Conversione da entità a DTO
        private NazioneNegozioDTO MapToDto(DbNazioneNegozio entity)
        {
            return new NazioneNegozioDTO
            {
                Nne_IDAuto = entity.Nne_IDAuto,
                Nne_IDNegozio = entity.Nne_IDNegozio,
                Nne_IDTipoCampo = entity.Nne_IDTipoCampo,
                Nne_Valore = entity.Nne_Valore
            };
        }

        // Conversione da DTO a entità
        private DbNazioneNegozio MapToEntity(NazioneNegozioDTO dto)
        {
            return new DbNazioneNegozio
            {
                Nne_IDAuto = dto.Nne_IDAuto,
                Nne_IDNegozio = dto.Nne_IDNegozio,
                Nne_IDTipoCampo = dto.Nne_IDTipoCampo,
                Nne_Valore = dto.Nne_Valore
            };
        }
    }
}