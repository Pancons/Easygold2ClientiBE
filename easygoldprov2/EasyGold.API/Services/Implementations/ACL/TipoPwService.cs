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
    public class TipoPwService : ITipoPwService
    {
        private readonly ITipoPwRepository _repository;

        public TipoPwService(ITipoPwRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TipoPwDTO>> GetAllAsync(TipoPwListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<TipoPwDTO>(items, total);
        }
    
        public async Task<TipoPwDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TipoPwDTO> AddAsync(TipoPwDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TipoPwDTO> UpdateAsync(TipoPwDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tpp_IDAuto);
            if (entity == null) return null;
     
            entity.Tpp_TipoPw = dto.Tpp_TipoPw;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        //QUESTO
        private TipoPwDTO MapToDto(DbTipoPw entity)
        {
            return new TipoPwDTO
            {
                Tpp_IDAuto = entity.Tpp_IDAuto,
                Tpp_TipoPw = entity.Tpp_TipoPw
            };
        }

        private DbTipoPw MapToEntity(TipoPwDTO dto)
        {
            return new DbTipoPw
            {
                Tpp_IDAuto = dto.Tpp_IDAuto,
                Tpp_TipoPw = dto.Tpp_TipoPw
            };
        }
    }
}
