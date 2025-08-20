using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;

        public ConfigService(IConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ConfigDTO>> GetAllAsync(ConfigListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ConfigDTO>(dtos, total);
        }

        public async Task<ConfigDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ConfigDTO> AddAsync(ConfigDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ConfigDTO> UpdateAsync(ConfigDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Sys_IDAuto, language);
            if (entity == null) return null;

            entity.Sys_NomeCampo = dto.Sys_NomeCampo;
            entity.Sys_Valore = dto.Sys_Valore;
            entity.Sys_Lunghezza = dto.Sys_Lunghezza;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ConfigDTO MapToDto(DbConfig entity)
        {
            return new ConfigDTO
            {
                Sys_IDAuto = entity.Sys_IDAuto,
                Sys_NomeCampo = entity.Sys_NomeCampo,
                Sys_Valore = entity.Sys_Valore,
                Sys_Lunghezza = entity.Sys_Lunghezza
            };
        }

        private DbConfig MapToEntity(ConfigDTO dto)
        {
            return new DbConfig
            {
                Sys_IDAuto = dto.Sys_IDAuto,
                Sys_NomeCampo = dto.Sys_NomeCampo,
                Sys_Valore = dto.Sys_Valore,
                Sys_Lunghezza = dto.Sys_Lunghezza
            };
        }
    }
}