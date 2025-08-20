using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CreditCardDTO>> GetAllAsync(CreditCardListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<CreditCardDTO>(dtos, total);
        }

        public async Task<CreditCardDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CreditCardDTO> AddAsync(CreditCardDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CreditCardDTO> UpdateAsync(CreditCardDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Crc_IDAuto, language);
            if (entity == null) return null;

            // Aggiorna i campi dell'entità
            entity.Crc_Card = dto.Crc_Card;
            entity.Crc_Fee = dto.Crc_Fee;
            entity.Crc_Ordinamento = dto.Crc_Ordinamento;
            entity.Crc_Annulla = dto.Crc_Annulla;
            // Aggiorna traduzioni dal DTO
            entity.CreditCardLangs = dto.Lingue.Select(MapToEntityLang).ToList();

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CreditCardDTO MapToDto(DbCreditCard entity)
        {
            return new CreditCardDTO
            {
                Crc_IDAuto = entity.Crc_IDAuto,
                Crc_Card = entity.Crc_Card,
                Crc_Fee = entity.Crc_Fee,
                Crc_Ordinamento = entity.Crc_Ordinamento,
                Crc_Annulla = entity.Crc_Annulla,
                Lingue = entity.CreditCardLangs.Select(lang => new CreditCardLangDTO
                {
                    CrcId_ISONum = lang.CrcId_ISONum,
                    CrcId_ID = lang.CrcId_ID,
                    CrcId_Brand = lang.CrcId_Brand
                }).ToList()
            };
        }

        private DbCreditCard MapToEntity(CreditCardDTO dto)
        {
            return new DbCreditCard
            {
                Crc_IDAuto = dto.Crc_IDAuto,
                Crc_Card = dto.Crc_Card,
                Crc_Fee = dto.Crc_Fee,
                Crc_Ordinamento = dto.Crc_Ordinamento,
                Crc_Annulla = dto.Crc_Annulla,
                CreditCardLangs = dto.Lingue.Select(MapToEntityLang).ToList()
            };
        }

        private DbCreditCardLang MapToEntityLang(CreditCardLangDTO dto)
        {
            return new DbCreditCardLang
            {
                CrcId_ISONum = dto.CrcId_ISONum,
                CrcId_ID = dto.CrcId_ID,
                CrcId_Brand = dto.CrcId_Brand
            };
        }
    }
}