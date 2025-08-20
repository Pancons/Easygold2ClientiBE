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
    public class TipoPermessoService : ITipoPermessoService
    {
        private readonly ITipoPermessoRepository _repository;

        public TipoPermessoService(ITipoPermessoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipoPermessoDTO>> GetAllAsync(TipoPermessoListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<TipoPermessoDTO>(items, total);
        }

       public async Task<TipoPermessoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoPermessoDTO> AddAsync(TipoPermessoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoPermessoDTO> UpdateAsync(TipoPermessoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tpa_IDAuto);
            if (entity == null) return null;
     
            entity.Tpa_TipoPermesso = dto.Tpa_TipoPermesso;
            entity.Tpa_LivelloPermesso = dto.Tpa_LivelloPermesso;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

           //QUESTO
        private TipoPermessoDTO MapToDto(DbTipoPermesso entity)
        {
            return new TipoPermessoDTO
            {
                Tpa_IDAuto = entity.Tpa_IDAuto,
                Tpa_TipoPermesso = entity.Tpa_TipoPermesso,
                Tpa_LivelloPermesso = entity.Tpa_LivelloPermesso

            };
        }

        private DbTipoPermesso MapToEntity(TipoPermessoDTO dto)
        {
            return new DbTipoPermesso
            {
                Tpa_IDAuto = dto.Tpa_IDAuto,
                Tpa_TipoPermesso = dto.Tpa_TipoPermesso,
                Tpa_LivelloPermesso = dto.Tpa_LivelloPermesso

            };
        }
    }
}
