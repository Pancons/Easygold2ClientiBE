using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class IdISONazioniService : IIdISONazioniService
    {
        private readonly IIdISONazioniRepository _repository;

        public IdISONazioniService(IIdISONazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<IdISONazioniDTO>> GetAllAsync(IdISONazioniListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<IdISONazioniDTO>(items, total);
        }

        public async Task<IdISONazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<IdISONazioniDTO> AddAsync(IdISONazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<IdISONazioniDTO> UpdateAsync(IdISONazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Ntnid_ID);
            if (entity == null) return null;

            entity.Ntnid_Nazione = dto.Ntnid_Nazione;
            entity.Ntnid_Capitale = dto.Ntnid_Capitale;
            entity.Ntn_CapitaleDeFacto = dto.Ntn_CapitaleDeFacto;
            entity.Ntn_CapitaleAmm = dto.Ntn_CapitaleAmm;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private IdISONazioniDTO MapToDto(DbIdISONazioni entity)
        {
            return new IdISONazioniDTO
            {
                Ntnid_ISONum = entity.Ntnid_ISONum,
                Ntnid_ID = entity.Ntnid_ID,
                Ntnid_Nazione = entity.Ntnid_Nazione,
                Ntnid_Capitale = entity.Ntnid_Capitale,
                Ntn_CapitaleDeFacto = entity.Ntn_CapitaleDeFacto,
                Ntn_CapitaleAmm = entity.Ntn_CapitaleAmm,
            };
        }

        private DbIdISONazioni MapToEntity(IdISONazioniDTO dto)
        {
            return new DbIdISONazioni
            {
                Ntnid_ISONum = dto.Ntnid_ISONum,
                Ntnid_ID = dto.Ntnid_ID,
                Ntnid_Nazione = dto.Ntnid_Nazione,
                Ntnid_Capitale = dto.Ntnid_Capitale,
                Ntn_CapitaleDeFacto = dto.Ntn_CapitaleDeFacto,
                Ntn_CapitaleAmm = dto.Ntn_CapitaleAmm,
            };
        }
    }
}