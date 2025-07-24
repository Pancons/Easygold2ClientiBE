using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class GruppiService : IGruppiService
    {
        private readonly IGruppiRepository _repository;

        public GruppiService(IGruppiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<GruppiDTO>> GetAllAsync(GruppiListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<GruppiDTO>(dtos, total);
        }

        public async Task<GruppiDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<GruppiDTO> AddAsync(GruppiDTO dto,string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity,language);
            return MapToDto(entity);
        }

        public async Task<GruppiDTO> UpdateAsync(GruppiDTO dto,string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Grp_IDAuto,language);
            if (entity == null) return null;

            entity.Grp_NomeGruppo = dto.Grp_NomeGruppo;
            entity.Grp_DesGruppo = dto.Grp_DesGruppo;
            entity.Grp_SuperAdmin = dto.Grp_SuperAdmin;
            entity.Grp_Bloccato = dto.Grp_Bloccato;

            await _repository.UpdateAsync(entity,language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private GruppiDTO MapToDto(DbGruppi entity)
        {
            return new GruppiDTO
            {
                Grp_IDAuto = entity.Grp_IDAuto,
                Grp_NomeGruppo = entity.Grp_NomeGruppo,
                Grp_DesGruppo = entity.Grp_DesGruppo,
                Grp_SuperAdmin = entity.Grp_SuperAdmin,
                Grp_Bloccato = (bool)entity.Grp_Bloccato,
                // Map language-specific fields from GruppiLang
            };
        }

        private DbGruppi MapToEntity(GruppiDTO dto)
        {
            return new DbGruppi
            {
                Grp_IDAuto = dto.Grp_IDAuto,
                Grp_NomeGruppo = dto.Grp_NomeGruppo,
                Grp_DesGruppo = dto.Grp_DesGruppo,
                Grp_SuperAdmin = dto.Grp_SuperAdmin,
                Grp_Bloccato = dto.Grp_Bloccato,
                // Map any necessary relationships
            };
        }
    }
}