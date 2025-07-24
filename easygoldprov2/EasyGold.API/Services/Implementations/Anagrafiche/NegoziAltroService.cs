using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.API.Services.Interfaces.Anagrafiche;

namespace EasyGold.API.Services.Implementations.Anagrafiche
{
    public class NegoziAltroService : INegoziAltroService
    {
        private readonly INegoziAltroRepository _repository;

        public NegoziAltroService(INegoziAltroRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NegozioAltroDTO>> GetAllAsync(NegozioAltroListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NegozioAltroDTO>(list, total);
        }

        public async Task<NegozioAltroDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NegozioAltroDTO> AddAsync(NegozioAltroDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Id = entity.Nea_IDAuto;
            return dto;
        }

        public async Task<NegozioAltroDTO> UpdateAsync(NegozioAltroDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return null;

            entity.Nea_IDNazione = dto.NazioneId;
            entity.Nea_IDValuta = dto.ValutaId;
            entity.Nea_IDListino = dto.ListinoId;
            entity.Nea_IDAliquotaIVA = dto.AliquotaIVAId;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NegozioAltroDTO MapToDto(DbNegoziAltro entity)
        {
            return new NegozioAltroDTO
            {
                Id = entity.Nea_IDAuto,
                NazioneId = entity.Nea_IDNazione,
                ValutaId = entity.Nea_IDValuta,
                ListinoId = entity.Nea_IDListino,
                AliquotaIVAId = entity.Nea_IDAliquotaIVA
            };
        }

        private DbNegoziAltro MapToEntity(NegozioAltroDTO dto)
        {
            return new DbNegoziAltro
            {
                Nea_IDAuto = dto.Id,
                Nea_IDNazione = dto.NazioneId,
                Nea_IDValuta = dto.ValutaId,
                Nea_IDListino = dto.ListinoId,
                Nea_IDAliquotaIVA = dto.AliquotaIVAId
            };
        }
    }
}