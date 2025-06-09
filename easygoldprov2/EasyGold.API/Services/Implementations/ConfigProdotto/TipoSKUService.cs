using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.ConfigProdotto;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations.ConfigProdotto
{
    public class TipoSKUService : ITipoSKUService
    {
        private readonly ITipoSKURepository _repository;

        public TipoSKUService(ITipoSKURepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoSKUDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<TipoSKUDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoSKUDTO> AddAsync(TipoSKUDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoSKUDTO> UpdateAsync(TipoSKUDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Sku_IdAuto);
            if (entity == null) return null;

            entity.Sku_TipoSKU = dto.Sku_TipoSKU;
            entity.Sku_Valore = dto.Sku_Valore;
            entity.Sku_Annullato = dto.Sku_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TipoSKUDTO MapToDto(DbTipoSKU entity)
        {
            return new TipoSKUDTO
            {
                Sku_IdAuto = entity.Sku_IdAuto,
                Sku_TipoSKU = entity.Sku_TipoSKU,
                Sku_Valore = entity.Sku_Valore,
                Sku_Annullato = entity.Sku_Annullato
            };
        }

        private DbTipoSKU MapToEntity(TipoSKUDTO dto)
        {
            return new DbTipoSKU
            {
                Sku_IdAuto = dto.Sku_IdAuto,
                Sku_TipoSKU = dto.Sku_TipoSKU,
                Sku_Valore = dto.Sku_Valore,
                Sku_Annullato = dto.Sku_Annullato
            };
        }
    }
}