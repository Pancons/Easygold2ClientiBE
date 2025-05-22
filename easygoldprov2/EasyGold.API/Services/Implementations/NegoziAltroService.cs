using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class NegoziAltroService : INegoziAltroService
    {
        private readonly INegoziAltroRepository _repository;

        public NegoziAltroService(INegoziAltroRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NegoziAltroDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NegoziAltroDTO>(list, list.Count);
        }

        public async Task<NegoziAltroDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NegoziAltroDTO> AddAsync(NegoziAltroDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Nea_IDAuto = entity.Nea_IDAuto;
            return dto;
        }

        public async Task<NegoziAltroDTO> UpdateAsync(NegoziAltroDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Nea_IDAuto);
            if (entity == null) return null;

            entity.Nea_IDNazione = dto.Nea_IDNazione;
            entity.Nea_IDValuta = dto.Nea_IDValuta;
            entity.Nea_IDListino = dto.Nea_IDListino;
            entity.Nea_IDAliquotaIVA = dto.Nea_IDAliquotaIVA;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NegoziAltroDTO MapToDto(DbNegoziAltro entity)
        {
            if (entity == null) return null;
            return new NegoziAltroDTO
            {
                Nea_IDAuto = entity.Nea_IDAuto,
                Nea_IDNazione = entity.Nea_IDNazione,
                Nea_IDValuta = entity.Nea_IDValuta,
                Nea_IDListino = entity.Nea_IDListino,
                Nea_IDAliquotaIVA = entity.Nea_IDAliquotaIVA
            };
        }

        private DbNegoziAltro MapToEntity(NegoziAltroDTO dto)
        {
            if (dto == null) return null;
            return new DbNegoziAltro
            {
                Nea_IDAuto = dto.Nea_IDAuto,
                Nea_IDNazione = dto.Nea_IDNazione,
                Nea_IDValuta = dto.Nea_IDValuta,
                Nea_IDListino = dto.Nea_IDListino,
                Nea_IDAliquotaIVA = dto.Nea_IDAliquotaIVA
            };
        }
    }
}