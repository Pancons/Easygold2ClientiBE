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

namespace EasyGold.API.Services.Implementations
{
    public class TipoTagProdottiService : ITipoTagProdottiService
    {
        private readonly ITipoTagProdottiRepository _repository;

        public TipoTagProdottiService(ITipoTagProdottiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipoTagProdottiDTO>> GetAllAsync(TipoTagProdottiListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TipoTagProdottiDTO>(dtos, total);
        }

        public async Task<TipoTagProdottiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoTagProdottiDTO> AddAsync(TipoTagProdottiDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoTagProdottiDTO> UpdateAsync(TipoTagProdottiDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tpt_IDAuto);
            if (entity == null) return null;

            entity.Tpt_Descrizione = dto.Tpt_Descrizione;
            entity.Tpt_TipoTag = dto.Tpt_TipoTag;
            entity.Tpt_NumGiorni = dto.Tpt_NumGiorni;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TipoTagProdottiDTO MapToDto(DbTipoTagProdotti entity)
        {
            return new TipoTagProdottiDTO
            {
                Tpt_IDAuto = entity.Tpt_IDAuto,
                Tpt_Descrizione = entity.Tpt_Descrizione,
                Tpt_TipoTag = entity.Tpt_TipoTag,
                Tpt_NumGiorni = entity.Tpt_NumGiorni
            };
        }

        private DbTipoTagProdotti MapToEntity(TipoTagProdottiDTO dto)
        {
            return new DbTipoTagProdotti
            {
                Tpt_IDAuto = dto.Tpt_IDAuto,
                Tpt_Descrizione = dto.Tpt_Descrizione,
                Tpt_TipoTag = dto.Tpt_TipoTag,
                Tpt_NumGiorni = dto.Tpt_NumGiorni
            };
        }
    }
}