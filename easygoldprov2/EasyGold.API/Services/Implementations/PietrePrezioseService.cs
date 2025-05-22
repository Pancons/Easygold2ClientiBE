using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.PietrePreziose;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class PietrePrezioseService : IPietrePrezioseService
    {
        private readonly IPietrePrezioseRepository _repository;

        public PietrePrezioseService(IPietrePrezioseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PietraPreziosaDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<PietraPreziosaDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<PietraPreziosaDTO> AddAsync(PietraPreziosaDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<PietraPreziosaDTO> UpdateAsync(PietraPreziosaDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Ppz_IdAuto);
            if (entity == null) return null;

            entity.Ppz_Pietra = dto.Ppz_Pietra;
            entity.Ppz_Diamante = dto.Ppz_Diamante;
            entity.Ppz_Annulla = dto.Ppz_Annulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private PietraPreziosaDTO MapToDto(DbPietraPreziosa entity)
        {
            return new PietraPreziosaDTO
            {
                Ppz_IdAuto = entity.Ppz_IdAuto,
                Ppz_Pietra = entity.Ppz_Pietra,
                Ppz_Diamante = entity.Ppz_Diamante,
                Ppz_Annulla = entity.Ppz_Annulla
            };
        }

        private DbPietraPreziosa MapToEntity(PietraPreziosaDTO dto)
        {
            return new DbPietraPreziosa
            {
                Ppz_IdAuto = dto.Ppz_IdAuto,
                Ppz_Pietra = dto.Ppz_Pietra,
                Ppz_Diamante = dto.Ppz_Diamante,
                Ppz_Annulla = dto.Ppz_Annulla
            };
        }
    }
}