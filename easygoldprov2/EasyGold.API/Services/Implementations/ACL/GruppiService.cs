using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class GruppiService : IGruppiService
    {
        private readonly IGruppiRepository _repository;

        public GruppiService(IGruppiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<GruppiDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<GruppiDTO>(list, list.Count);
        }

        public async Task<GruppiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<GruppiDTO> AddAsync(GruppiDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Grp_IDAuto = entity.Grp_IDAuto;
            return dto;
        }

        public async Task<GruppiDTO> UpdateAsync(GruppiDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Grp_IDAuto);
            if (entity == null) return null;

            entity.Grp_NomeGruppo = dto.Grp_NomeGruppo;
            entity.Grp_DesGruppo = dto.Grp_DesGruppo;
            entity.Grp_SuperAdmin = dto.Grp_SuperAdmin;
            entity.Grp_Bloccato = dto.Grp_Bloccato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private GruppiDTO MapToDto(DbGruppi entity)
        {
            if (entity == null) return null;
            return new GruppiDTO
            {
                Grp_IDAuto = entity.Grp_IDAuto,
                Grp_NomeGruppo = entity.Grp_NomeGruppo,
                Grp_DesGruppo = entity.Grp_DesGruppo ?? string.Empty,
                Grp_SuperAdmin = entity.Grp_SuperAdmin ?? false,
                Grp_Bloccato = entity.Grp_Bloccato ?? false
            };
        }

        private DbGruppi MapToEntity(GruppiDTO dto)
        {
            if (dto == null) return null;
            return new DbGruppi
            {
                Grp_IDAuto = dto.Grp_IDAuto,
                Grp_NomeGruppo = dto.Grp_NomeGruppo,
                Grp_DesGruppo = dto.Grp_DesGruppo,
                Grp_SuperAdmin = dto.Grp_SuperAdmin,
                Grp_Bloccato = dto.Grp_Bloccato
            };
        }
    }
}
