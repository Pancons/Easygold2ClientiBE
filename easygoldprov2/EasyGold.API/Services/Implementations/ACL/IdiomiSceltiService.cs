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
     public class IdiomiSceltiService : IIdiomiSceltiService
    {
        private readonly IIdiomiSceltiRepository _repository;

        public IdiomiSceltiService(IIdiomiSceltiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<IdiomiSceltiDTO>> GetAllAsync(IdiomiSceltiListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<IdiomiSceltiDTO>(dtos, total);
        }

        public async Task<IdiomiSceltiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<IdiomiSceltiDTO> AddAsync(IdiomiSceltiDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<IdiomiSceltiDTO> UpdateAsync(IdiomiSceltiDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Idm_IDAuto);
            if (entity == null) return null;

            entity.Idm_IDCliente = dto.Idm_IDCliente;
            entity.Idm_IDIdioma = dto.Idm_IDIdioma;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private IdiomiSceltiDTO MapToDto(DbIdiomiScelti entity)
        {
            return new IdiomiSceltiDTO
            {
                Idm_IDAuto = entity.Idm_IDAuto,
                Idm_IDCliente = entity.Idm_IDCliente,
                Idm_IDIdioma = entity.Idm_IDIdioma
            };
        }

        private DbIdiomiScelti MapToEntity(IdiomiSceltiDTO dto)
        {
            return new DbIdiomiScelti
            {
                Idm_IDAuto = dto.Idm_IDAuto,
                Idm_IDCliente = dto.Idm_IDCliente,
                Idm_IDIdioma = dto.Idm_IDIdioma
            };
        }
    }
}