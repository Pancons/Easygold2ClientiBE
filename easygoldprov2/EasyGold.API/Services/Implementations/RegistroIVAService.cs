using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.RegIVA;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;

namespace EasyGold.API.Services.Implementations
{
    public class RegistroIVAService : IRegistroIVAService
    {
        private readonly IRegistroIVARepository _repository;

        public RegistroIVAService(IRegistroIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<RegistroIVADTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(RegistroIVADTO.Rgi_Descrizione))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Rgi_Descrizione)
                            : entities.OrderBy(e => e.Rgi_Descrizione);
                    }
                    // Aggiungi altri campi se necessario
                }
            }

            var total = entities.Count();

            // Paginazione
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();

            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<RegistroIVADTO>(dtos, total);
        }

        public async Task<RegistroIVADTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<RegistroIVADTO> AddAsync(RegistroIVADTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            dto.RowIdAuto = entity.RowIdAuto;
            return dto;
        }

        public async Task<RegistroIVADTO> UpdateAsync(RegistroIVADTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static RegistroIVADTO ToDTO(DbRegistroIVA e) => new RegistroIVADTO
        {
            RowIdAuto = e.RowIdAuto,
            Rgi_Descrizione = e.Rgi_Descrizione,
            Rgi_Prefisso = e.Rgi_Prefisso,
            Rgi_Suffisso = e.Rgi_Suffisso,
            Rgi_Annulla = e.Rgi_Annulla
        };

        private static DbRegistroIVA ToEntity(RegistroIVADTO dto) => new DbRegistroIVA
        {
            RowIdAuto = dto.RowIdAuto ?? 0,
            Rgi_Descrizione = dto.Rgi_Descrizione,
            Rgi_Prefisso = dto.Rgi_Prefisso,
            Rgi_Suffisso = dto.Rgi_Suffisso,
            Rgi_Annulla = dto.Rgi_Annulla
        };
    }
}