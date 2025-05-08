using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.NumeriRegIVA;
using EasyGold.API.Models.Entities.NumeriRegIVA;

namespace EasyGold.API.Services.Implementations
{
    public class NumeriRegIVAService : INumeriRegIVAService
    {
        private readonly INumeriRegIVARepository _repository;

        public NumeriRegIVAService(INumeriRegIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NumeriRegIVADTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(NumeriRegIVADTO.Nri_Anno))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Nri_Anno)
                            : entities.OrderBy(e => e.Nri_Anno);
                    }
                    // Aggiungi altri campi se necessario
                }
            }

            var total = entities.Count();

            // Paginazione
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();

            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<NumeriRegIVADTO>(dtos, total);
        }

        public async Task<NumeriRegIVADTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<NumeriRegIVADTO> AddAsync(NumeriRegIVADTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            dto.RowIDAuto = entity.RowIDAuto;
            return dto;
        }

        public async Task<NumeriRegIVADTO> UpdateAsync(NumeriRegIVADTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static NumeriRegIVADTO ToDTO(DbNumeriRegIVA e) => new NumeriRegIVADTO
        {
            RowIDAuto = e.RowIDAuto,
            RowIDRegIVA = e.RowIDRegIVA,
            Nri_Anno = e.Nri_Anno,
            Nri_NumFattura = e.Nri_NumFattura
        };

        private static DbNumeriRegIVA ToEntity(NumeriRegIVADTO dto) => new DbNumeriRegIVA
        {
            RowIDAuto = dto.RowIDAuto ?? 0,
            RowIDRegIVA = dto.RowIDRegIVA,
            Nri_Anno = dto.Nri_Anno,
            Nri_NumFattura = dto.Nri_NumFattura
        };
    }
}