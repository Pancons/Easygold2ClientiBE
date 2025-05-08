using EasyGold.API.Services.Interfaces;
using EasyGold.API.Repositories.Interfaces;
using System.Linq; // Ensure this is present for LINQ
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;
using EasyGold.API.Models.Entities.Config;

namespace EasyGold.API.Services.Implementations
{
    public class ConfigLangService : IConfigLangService
    {
        private readonly IConfigLangRepository _repository;

        public ConfigLangService(IConfigLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ConfigLangDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Sorting (add more fields if needed)
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(ConfigLangDTO.SysLng_NomeCampo))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.SysLng_NomeCampo)
                            : entities.OrderBy(e => e.SysLng_NomeCampo);
                    }
                    // Add more sorting fields here if needed
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<ConfigLangDTO>(dtos, total);
        }
        public async Task<ConfigLangDTO> GetByIdAsync(int isoNum, int id)
        {
            var entity = await _repository.GetByIdAsync(isoNum, id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<ConfigLangDTO> AddAsync(ConfigLangDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<ConfigLangDTO> UpdateAsync(ConfigLangDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            await _repository.DeleteAsync(isoNum, id);
        }

        private static ConfigLangDTO ToDTO(DbConfigLang e) => new ConfigLangDTO
        {
            SysLng_ISONum = e.SysLng_ISONum,
            SysLng_ID = e.SysLng_ID,
            SysLng_NomeCampo = e.SysLng_NomeCampo
        };

        private static DbConfigLang ToEntity(ConfigLangDTO dto) => new DbConfigLang
        {
            SysLng_ISONum = dto.SysLng_ISONum,
            SysLng_ID = dto.SysLng_ID,
            SysLng_NomeCampo = dto.SysLng_NomeCampo
        };
    }
}