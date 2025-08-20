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
    public class RegIVAService : IRegIVAService
    {
        private readonly IRegIVARepository _repository;

        public RegIVAService(IRegIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<RegIVADTO>> GetAllAsync(RegIVAListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<RegIVADTO>(items, total);
        }

        public async Task<RegIVADTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<RegIVADTO> AddAsync(RegIVADTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<RegIVADTO> UpdateAsync(RegIVADTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.RowIdAuto);
            if (entity == null) return null;

            entity.RgiDescrizione = dto.RgiDescrizione;
            entity.RgiPrefisso = dto.RgiPrefisso;
            entity.RgiSuffisso = dto.RgiSuffisso;
            entity.RgiAnnulla = dto.RgiAnnulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private RegIVADTO MapToDto(DbRegIVA entity)
        {
            return new RegIVADTO
            {
                RowIdAuto = entity.RowIdAuto,
                RgiDescrizione = entity.RgiDescrizione,
                RgiPrefisso = entity.RgiPrefisso,
                RgiSuffisso = entity.RgiSuffisso,
                RgiAnnulla = entity.RgiAnnulla
            };
        }

        private DbRegIVA MapToEntity(RegIVADTO dto)
        {
            return new DbRegIVA
            {
                RowIdAuto = dto.RowIdAuto,
                RgiDescrizione = dto.RgiDescrizione,
                RgiPrefisso = dto.RgiPrefisso,
                RgiSuffisso = dto.RgiSuffisso,
                RgiAnnulla = dto.RgiAnnulla
                // Map any necessary properties or relationships if needed
            };
        }
    }
}