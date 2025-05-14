using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class CodPagamentoService : ICodPagamentoService
    {
        private readonly ICodPagamentoRepository _repository;

        public CodPagamentoService(ICodPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CodPagamentoDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(CodPagamentoDTO.Cpa_Descrizione))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Cpa_Descrizione)
                            : entities.OrderBy(e => e.Cpa_Descrizione);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<CodPagamentoDTO>(dtos, total);
        }

        public async Task<CodPagamentoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<CodPagamentoDTO> AddAsync(CodPagamentoDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<CodPagamentoDTO> UpdateAsync(CodPagamentoDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static CodPagamentoDTO ToDTO(DbCodPagamento e) => new CodPagamentoDTO
        {
            Cpa_IDAuto = e.Cpa_IDAuto,
            Cpa_Descrizione = e.Cpa_Descrizione,
            Cpa_Annullato = e.Cpa_Annullato
        };

        private static DbCodPagamento ToEntity(CodPagamentoDTO dto) => new DbCodPagamento
        {
            Cpa_IDAuto = dto.Cpa_IDAuto ?? 0,
            Cpa_Descrizione = dto.Cpa_Descrizione,
            Cpa_Annullato = dto.Cpa_Annullato
        };
    }
}