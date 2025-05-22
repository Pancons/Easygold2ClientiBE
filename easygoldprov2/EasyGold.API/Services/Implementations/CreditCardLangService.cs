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
    public class CreditCardLangService : ICreditCardLangService
    {
        private readonly ICreditCardLangRepository _repository;

        public CreditCardLangService(ICreditCardLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CreditCardLangDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(CreditCardLangDTO.Crcid_Brand))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Crcid_Brand)
                            : entities.OrderBy(e => e.Crcid_Brand);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<CreditCardLangDTO>(dtos, total);
        }

        public async Task<CreditCardLangDTO> GetByIdAsync(int isoNum, int id)
        {
            var entity = await _repository.GetByIdAsync(isoNum, id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<CreditCardLangDTO> AddAsync(CreditCardLangDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<CreditCardLangDTO> UpdateAsync(CreditCardLangDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            await _repository.DeleteAsync(isoNum, id);
        }

        private static CreditCardLangDTO ToDTO(DbCreditCardLang e) => new CreditCardLangDTO
        {
            Crcid_ISONum = e.Crcid_ISONum,
            Crcid_ID = e.Crcid_ID,
            Crcid_Brand = e.Crcid_Brand
        };

        private static DbCreditCardLang ToEntity(CreditCardLangDTO dto) => new DbCreditCardLang
        {
            Crcid_ISONum = dto.Crcid_ISONum,
            Crcid_ID = dto.Crcid_ID,
            Crcid_Brand = dto.Crcid_Brand
        };
    }
}