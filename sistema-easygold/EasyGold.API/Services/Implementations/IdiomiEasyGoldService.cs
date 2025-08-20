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
    public class IdiomiEasyGoldService : IIdiomiEasyGoldService
    {
        private readonly IIdiomiEasyGoldRepository _repository;

        public IdiomiEasyGoldService(IIdiomiEasyGoldRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<IdiomiEasyGoldDTO>> GetAllAsync(IdiomiEasyGoldListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<IdiomiEasyGoldDTO>(dtos, total);
        }

        public async Task<IdiomiEasyGoldDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<IdiomiEasyGoldDTO> AddAsync(IdiomiEasyGoldDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<IdiomiEasyGoldDTO> UpdateAsync(IdiomiEasyGoldDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Idm_IDAuto);
            if (entity == null) return null;

            entity.Idm_ISONum = dto.Idm_ISONum;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private IdiomiEasyGoldDTO MapToDto(DbIdiomiEasyGold entity)
        {
            return new IdiomiEasyGoldDTO
            {
                Idm_IDAuto = entity.Idm_IDAuto,
                Idm_ISONum = entity.Idm_ISONum
            };
        }

        private DbIdiomiEasyGold MapToEntity(IdiomiEasyGoldDTO dto)
        {
            return new DbIdiomiEasyGold
            {
                Idm_IDAuto = dto.Idm_IDAuto,
                Idm_ISONum = dto.Idm_ISONum
            };
        }
    }
}