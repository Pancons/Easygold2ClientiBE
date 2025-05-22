using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class TipiMetalloService : ITipiMetalloService
    {
        private readonly ITipiMetalloRepository _repository;

        public TipiMetalloService(ITipiMetalloRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipiMetalloDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TipiMetalloDTO>(list, list.Count);
        }

        public async Task<TipiMetalloDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipiMetalloDTO> AddAsync(TipiMetalloDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Tim_IDAuto = entity.Tim_IDAuto;
            return dto;
        }

        public async Task<TipiMetalloDTO> UpdateAsync(TipiMetalloDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tim_IDAuto);
            if (entity == null) return null;

            entity.Tim_Descrizione = dto.Tim_Descrizione;
            entity.Tim_Annullato = dto.Tim_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // --- Mapping manuale ---

        private TipiMetalloDTO MapToDto(DbTipiMetallo entity)
        {
            if (entity == null) return null;
            return new TipiMetalloDTO
            {
                Tim_IDAuto = entity.Tim_IDAuto,
                Tim_Descrizione = entity.Tim_Descrizione,
                Tim_Annullato = entity.Tim_Annullato
            };
        }

        private DbTipiMetallo MapToEntity(TipiMetalloDTO dto)
        {
            if (dto == null) return null;
            return new DbTipiMetallo
            {
                Tim_IDAuto = dto.Tim_IDAuto,
                Tim_Descrizione = dto.Tim_Descrizione,
                Tim_Annullato = dto.Tim_Annullato
            };
        }
    }
}