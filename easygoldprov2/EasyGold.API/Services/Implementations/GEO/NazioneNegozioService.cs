using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces.GEO;
using EasyGold.API.Repositories.Interfaces.GEO;

namespace EasyGold.API.Services.Implementations.GEO
{
    public class NazioneNegozioService : INazioneNegozioService
    {
        private readonly INazioneNegozioRepository _repository;

        public NazioneNegozioService(INazioneNegozioRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NazioneNegozioDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NazioneNegozioDTO>(list, list.Count);
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
            dto.Nne_IDAuto = entity.Nne_IDAuto;
            return dto;
        }

        public async Task<NazioneNegozioDTO> UpdateAsync(NazioneNegozioDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Nne_IDAuto);
            if (entity == null) return null;

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

        private NazioneNegozioDTO MapToDto(DbNazioneNegozio entity)
        {
            if (entity == null) return null;
            return new NazioneNegozioDTO
            {
                Nne_IDAuto = entity.Nne_IDAuto,
                Nne_IDNegozio = entity.Nne_IDNegozio,
                Nne_IDTipoCampo = entity.Nne_IDTipoCampo,
                Nne_Valore = entity.Nne_Valore
            };
        }

        private DbNazioneNegozio MapToEntity(NazioneNegozioDTO dto)
        {
            if (dto == null) return null;
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