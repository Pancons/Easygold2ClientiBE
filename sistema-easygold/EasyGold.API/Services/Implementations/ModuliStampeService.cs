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
    public class ModuliStampeService : IModuliStampeService
    {
        private readonly IModuliStampeRepository _repository;

        public ModuliStampeService(IModuliStampeRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ModuliStampeDTO>> GetAllAsync(ModuliStampeListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ModuliStampeDTO>(dtos, total);
        }

        public async Task<ModuliStampeDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ModuliStampeDTO> AddAsync(ModuliStampeDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<ModuliStampeDTO> UpdateAsync(ModuliStampeDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Mst_IDAuto);
            if (entity == null) return null;

            entity.Mst_Descrizione = dto.Mst_Descrizione;
            entity.Mst_NomeModulo = dto.Mst_NomeModulo;
            entity.Mst_TipoModulo = dto.Mst_TipoModulo;
            entity.Mst_Annullato = dto.Mst_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ModuliStampeDTO MapToDto(DbModuliStampe entity)
        {
            return new ModuliStampeDTO
            {
                Mst_IDAuto = entity.Mst_IDAuto,
                Mst_Descrizione = entity.Mst_Descrizione,
                Mst_NomeModulo = entity.Mst_NomeModulo,
                Mst_TipoModulo = entity.Mst_TipoModulo,
                Mst_Annullato = entity.Mst_Annullato
            };
        }

        private DbModuliStampe MapToEntity(ModuliStampeDTO dto)
        {
            return new DbModuliStampe
            {
                Mst_IDAuto = dto.Mst_IDAuto,
                Mst_Descrizione = dto.Mst_Descrizione,
                Mst_NomeModulo = dto.Mst_NomeModulo,
                Mst_TipoModulo = dto.Mst_TipoModulo,
                Mst_Annullato = dto.Mst_Annullato
            };
        }
    }
}