using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;


namespace EasyGold.API.Services.Implementations
{
    public class CauProgressiviService : ICauProgressiviService
    {
        private readonly ICauProgressiviRepository _repository;

        public CauProgressiviService(ICauProgressiviRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CauProgressiviDTO>> GetAllAsync(CauProgressiviListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<CauProgressiviDTO>(dtos, total);
        }

        public async Task<CauProgressiviDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CauProgressiviDTO> AddAsync(CauProgressiviDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CauProgressiviDTO> UpdateAsync(CauProgressiviDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Cpr_IDAuto, language);
            if (entity == null) return null;

            entity.Cpr_Descrizione = dto.Cpr_Descrizione;
            entity.Cpr_CalcGiacenza = dto.Cpr_CalcGiacenza;
            entity.Cpr_CalcDisponibilita = dto.Cpr_CalcDisponibilita;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CauProgressiviDTO MapToDto(DbCauProgressivi entity)
        {
            return new CauProgressiviDTO
            {
                Cpr_IDAuto = entity.Cpr_IDAuto,
                Cpr_Descrizione = entity.Cpr_Descrizione,
                Cpr_CalcGiacenza = entity.Cpr_CalcGiacenza,
                Cpr_CalcDisponibilita = entity.Cpr_CalcDisponibilita,
                // Additional fields can be mapped if necessary
            };
        }

        private DbCauProgressivi MapToEntity(CauProgressiviDTO dto)
        {
            return new DbCauProgressivi
            {
                Cpr_IDAuto = dto.Cpr_IDAuto,
                Cpr_Descrizione = dto.Cpr_Descrizione,
                Cpr_CalcGiacenza = dto.Cpr_CalcGiacenza,
                Cpr_CalcDisponibilita = dto.Cpr_CalcDisponibilita,
                // Additional fields can be mapped if necessary
            };
        }
    }
}