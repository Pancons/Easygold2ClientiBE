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
    public class NumeriRegIVAService : INumeriRegIVAService
    {
        private readonly INumeriRegIVARepository _repository;

        public NumeriRegIVAService(INumeriRegIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NumeriRegIVADTO>> GetAllAsync(NumeriRegIVAListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NumeriRegIVADTO>(items, total);
        }

        public async Task<NumeriRegIVADTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NumeriRegIVADTO> AddAsync(NumeriRegIVADTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<NumeriRegIVADTO> UpdateAsync(NumeriRegIVADTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.RowIDAuto);
            if (entity == null) return null;

            entity.RowIDRegIVA = dto.RowIDRegIVA;
            entity.NriAnno = dto.NriAnno;
            entity.NriNumFattura = dto.NriNumFattura;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NumeriRegIVADTO MapToDto(DbNumeriRegIVA entity)
        {
            return new NumeriRegIVADTO
            {
                RowIDAuto = entity.RowIDAuto,
                RowIDRegIVA = entity.RowIDRegIVA,
                NriAnno = entity.NriAnno,
                NriNumFattura = entity.NriNumFattura
                // Map any necessary relationships or additional data if needed
            };
        }

        private DbNumeriRegIVA MapToEntity(NumeriRegIVADTO dto)
        {
            return new DbNumeriRegIVA
            {
                RowIDAuto = dto.RowIDAuto,
                RowIDRegIVA = dto.RowIDRegIVA,
                NriAnno = dto.NriAnno,
                NriNumFattura = dto.NriNumFattura
                // Map any necessary relationships or additional data if needed
            };
        }
    }
}