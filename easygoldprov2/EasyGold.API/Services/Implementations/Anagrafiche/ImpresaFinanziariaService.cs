using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.ImpresaFinanziaria;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations.Anagrafiche
{
    public class ImpresaFinanziariaService : IImpresaFinanziariaService
    {
        private readonly IImpresaFinanziariaRepository _repository;

        public ImpresaFinanziariaService(IImpresaFinanziariaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ImpresaFinanziariaDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<ImpresaFinanziariaDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ImpresaFinanziariaDTO> AddAsync(ImpresaFinanziariaDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<ImpresaFinanziariaDTO> UpdateAsync(ImpresaFinanziariaDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Imf_IdAuto);
            if (entity == null) return null;

            entity.Imf_Descrizione = dto.Imf_Descrizione;
            entity.Imf_IBAN = dto.Imf_IBAN;
            entity.Imf_BIC = dto.Imf_BIC;
            entity.Imf_Annullato = dto.Imf_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ImpresaFinanziariaDTO MapToDto(DbImpresaFinanziaria entity)
        {
            return new ImpresaFinanziariaDTO
            {
                Imf_IdAuto = entity.Imf_IdAuto,
                Imf_Descrizione = entity.Imf_Descrizione,
                Imf_IBAN = entity.Imf_IBAN,
                Imf_BIC = entity.Imf_BIC,
                Imf_Annullato = entity.Imf_Annullato
            };
        }

        private DbImpresaFinanziaria MapToEntity(ImpresaFinanziariaDTO dto)
        {
            return new DbImpresaFinanziaria
            {
                Imf_IdAuto = dto.Imf_IdAuto,
                Imf_Descrizione = dto.Imf_Descrizione,
                Imf_IBAN = dto.Imf_IBAN,
                Imf_BIC = dto.Imf_BIC,
                Imf_Annullato = dto.Imf_Annullato
            };
        }
    }
}