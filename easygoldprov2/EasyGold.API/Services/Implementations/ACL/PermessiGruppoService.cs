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
    public class PermessiGruppoService : IPermessiGruppoService
    {
        private readonly IPermessiGruppoRepository _repository;

        public PermessiGruppoService(IPermessiGruppoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<PermessiGruppoDTO>> GetAllAsync(PermessiGruppoListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<PermessiGruppoDTO>(dtos, total);
        }

        public async Task<PermessiGruppoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<PermessiGruppoDTO> AddAsync(PermessiGruppoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<PermessiGruppoDTO> UpdateAsync(PermessiGruppoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Abg_IDAuto);
            if (entity == null) return null;

            entity.Abg_IDGruppo = dto.Abg_IDGruppo;
            entity.Abg_IDFunzione = dto.Abg_IDFunzione;
            entity.Abg_IDTipoPermesso = dto.Abg_IDTipoPermesso;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private PermessiGruppoDTO MapToDto(DbPermessiGruppo entity)
        {
            return new PermessiGruppoDTO
            {
                Abg_IDAuto = entity.Abg_IDAuto,
                Abg_IDGruppo = entity.Abg_IDGruppo,
                Abg_IDFunzione = entity.Abg_IDFunzione,
                Abg_IDTipoPermesso = entity.Abg_IDTipoPermesso
            };
        }

        private DbPermessiGruppo MapToEntity(PermessiGruppoDTO dto)
        {
            return new DbPermessiGruppo
            {
                Abg_IDAuto = dto.Abg_IDAuto,
                Abg_IDGruppo = dto.Abg_IDGruppo,
                Abg_IDFunzione = dto.Abg_IDFunzione,
                Abg_IDTipoPermesso = dto.Abg_IDTipoPermesso
            };
        }
    }
}