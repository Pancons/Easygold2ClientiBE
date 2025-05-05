using EasyGold.API.Services.Interfaces;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.ConfigLag;
using EasyGold.API.Models.Entities;
using System.Linq; // Ensure this is present for LINQ
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Models;

namespace EasyGold.API.Services.Implementations
{
    public class ConfigLagService : IConfigLagService
    {
        private readonly IConfigLagRepository _repository;

        public ConfigLagService(IConfigLagRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ConfigLagDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Sorting (add more fields if needed)
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(ConfigLagDTO.Sysid_NomeCampo))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Sysid_NomeCampo)
                            : entities.OrderBy(e => e.Sysid_NomeCampo);
                    }
                    // Add more sorting fields here if needed
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<ConfigLagDTO>(dtos, total);
        }
        public async Task<ConfigLagDTO> GetByIdAsync(int isoNum, int id)
        {
            var entity = await _repository.GetByIdAsync(isoNum, id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<ConfigLagDTO> AddAsync(ConfigLagDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<ConfigLagDTO> UpdateAsync(ConfigLagDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            await _repository.DeleteAsync(isoNum, id);
        }

        private static ConfigLagDTO ToDTO(DbConfigLag e) => new ConfigLagDTO
        {
            Sysid_ISONum = e.Sysid_ISONum,
            Sysid_ID = e.Sysid_ID,
            Sysid_NomeCampo = e.Sysid_NomeCampo
        };

        private static DbConfigLag ToEntity(ConfigLagDTO dto) => new DbConfigLag
        {
            Sysid_ISONum = dto.Sysid_ISONum,
            Sysid_ID = dto.Sysid_ID,
            Sysid_NomeCampo = dto.Sysid_NomeCampo
        };
    }
}