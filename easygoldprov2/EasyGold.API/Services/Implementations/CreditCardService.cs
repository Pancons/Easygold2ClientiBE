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
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CreditCardDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(CreditCardDTO.Crc_Card))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Crc_Card)
                            : entities.OrderBy(e => e.Crc_Card);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<CreditCardDTO>(dtos, total);
        }

        public async Task<CreditCardDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<CreditCardDTO> AddAsync(CreditCardDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<CreditCardDTO> UpdateAsync(CreditCardDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static CreditCardDTO ToDTO(DbCreditCard e) => new CreditCardDTO
        {
            Crc_IDAuto = e.Crc_IDAuto,
            Crc_Card = e.Crc_Card,
            Crc_Fee = e.Crc_Fee,
            Crc_Ordinamento = e.Crc_Ordinamento,
            Crc_Annulla = e.Crc_Annulla
        };

        private static DbCreditCard ToEntity(CreditCardDTO dto) => new DbCreditCard
        {
            Crc_IDAuto = dto.Crc_IDAuto ?? 0,
            Crc_Card = dto.Crc_Card,
            Crc_Fee = dto.Crc_Fee,
            Crc_Ordinamento = dto.Crc_Ordinamento,
            Crc_Annulla = dto.Crc_Annulla
        };
    }
}