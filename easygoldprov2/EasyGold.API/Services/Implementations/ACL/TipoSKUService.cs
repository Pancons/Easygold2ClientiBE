using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class TipoSKUService : ITipoSKUService
    {
        private readonly ITipoSKURepository _repository;

        public TipoSKUService(ITipoSKURepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipoSKUDTO>> GetAllAsync(TipoSKUListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TipoSKUDTO>(dtos, total);
        }

        public async Task<TipoSKUDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoSKUDTO> AddAsync(TipoSKUDTO dto)
        {
            /*if (!IsValoreValid(dto.Sku_TipoSKU, dto.Sku_Valore))
            {
                throw new ValidationException("Il valore dell'SKU non è valido per il tipo di SKU specificato.");
            }*/

            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoSKUDTO> UpdateAsync(TipoSKUDTO dto)
        {
            /*if (!IsValoreValid(dto.Sku_TipoSKU, dto.Sku_Valore))
            {
                throw new ValidationException("Il valore dell'SKU non è valido per il tipo di SKU specificato.");
            }*/

            var entity = await _repository.GetByIdAsync(dto.Sku_IDAuto);
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
                Sku_IDAuto = entity.Sku_IDAuto,
                Sku_TipoSKU = entity.Sku_TipoSKU,
                Sku_Valore = entity.Sku_Valore,
                Sku_Annullato = entity.Sku_Annullato
            };
        }

        private DbTipoSKU MapToEntity(TipoSKUDTO dto)
        {
            return new DbTipoSKU
            {
                Sku_IDAuto = dto.Sku_IDAuto,
                Sku_TipoSKU = dto.Sku_TipoSKU,
                Sku_Valore = dto.Sku_Valore,
                Sku_Annullato = dto.Sku_Annullato
            };
        }

        /*private bool IsValoreValid(int tipoSKU, string valore)
        {
            if (tipoSKU == 0 || tipoSKU == 1 || tipoSKU == 2)
            {
                return double.TryParse(valore, out _);
            }
            else if (tipoSKU == 3)
            {
                return true; // Alfanumerico, nessun controllo specifico necessario
            }
            return false; // Tipo SKU non riconosciuto
        }*/
    }
}