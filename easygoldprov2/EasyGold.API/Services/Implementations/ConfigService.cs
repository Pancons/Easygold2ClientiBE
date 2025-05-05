using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.Config;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;

        public ConfigService(IConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ConfigDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(ConfigDTO.Sys_NomeCampo))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Sys_NomeCampo)
                            : entities.OrderBy(e => e.Sys_NomeCampo);
                    }
                    // Aggiungi altri campi se necessario
                }
            }

            var total = entities.Count();

            // Paginazione
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();

            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<ConfigDTO>(dtos, total);
        }

        public async Task<ConfigDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<ConfigDTO> AddAsync(ConfigDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<ConfigDTO> UpdateAsync(ConfigDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Conversioni esplicite
        private static ConfigDTO ToDTO(DbConfig e) => new ConfigDTO
        {
            Sys_IDAuto = e.Sys_IDAuto,
            Sys_Sezione = e.Sys_Sezione,
            Sys_Nazione = e.Sys_Nazione,
            Sys_NomeCampo = e.Sys_NomeCampo,
            Sys_TipoCampo = e.Sys_TipoCampo,
            Sys_Valore = e.Sys_Valore,
            Sys_Lunghezza = e.Sys_Lunghezza
        };

        private static DbConfig ToEntity(ConfigDTO dto) => new DbConfig
        {
            Sys_IDAuto = dto.Sys_IDAuto ?? 0,
            Sys_Sezione = dto.Sys_Sezione,
            Sys_Nazione = dto.Sys_Nazione,
            Sys_NomeCampo = dto.Sys_NomeCampo,
            Sys_TipoCampo = dto.Sys_TipoCampo,
            Sys_Valore = dto.Sys_Valore,
            Sys_Lunghezza = dto.Sys_Lunghezza
        };
    }
}