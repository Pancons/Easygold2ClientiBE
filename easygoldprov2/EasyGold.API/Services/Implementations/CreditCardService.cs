
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;



using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.CreditCard;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<CreditCardDTO>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }





















        public async Task<CreditCardDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CreditCardDTO> AddAsync(CreditCardDTO dto)
        {

            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);

            return MapToDto(entity);
        }

        public async Task<CreditCardDTO> UpdateAsync(CreditCardDTO dto)
        {

            var entity = await _repository.GetByIdAsync(dto.Crc_IdAuto);
            if (entity == null) return null;

            entity.Crc_Card = dto.Crc_Card;
            entity.Crc_Fee = dto.Crc_Fee;
            entity.Crc_Ordinamento = dto.Crc_Ordinamento;
            entity.Crc_Annulla = dto.Crc_Annulla;

            await _repository.UpdateAsync(entity);

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
                Crc_IdAuto = entity.Crc_IdAuto,
                Crc_Card = entity.Crc_Card,
                Crc_Fee = entity.Crc_Fee,
                Crc_Ordinamento = entity.Crc_Ordinamento,
                Crc_Annulla = entity.Crc_Annulla
            };
        }

        private DbCreditCard MapToEntity(CreditCardDTO dto)
        {
            return new DbCreditCard
            {
                Crc_IdAuto = dto.Crc_IdAuto,
                Crc_Card = dto.Crc_Card,
                Crc_Fee = dto.Crc_Fee,
                Crc_Ordinamento = dto.Crc_Ordinamento,
                Crc_Annulla = dto.Crc_Annulla
            };
        }
    }
}
