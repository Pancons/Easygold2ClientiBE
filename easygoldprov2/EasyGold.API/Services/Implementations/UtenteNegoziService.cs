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
    public class UtenteNegoziService : IUtenteNegoziService
    {
        private readonly IUtenteNegoziRepository _repository;

        public UtenteNegoziService(IUtenteNegoziRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<UtenteNegoziDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<UtenteNegoziDTO>(list, list.Count);
        }

        public async Task<UtenteNegoziDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<UtenteNegoziDTO> AddAsync(UtenteNegoziDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Utn_ID = entity.Utn_ID;
            return dto;
        }

        public async Task<UtenteNegoziDTO> UpdateAsync(UtenteNegoziDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Utn_ID);
            if (entity == null) return null;

            entity.Utn_IDNegozio = dto.Utn_IDNegozio;
            entity.Utn_Annullato = dto.Utn_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // --- Mapping manuale ---

        private UtenteNegoziDTO MapToDto(DbUtenteNegozi entity)
        {
            if (entity == null) return null;
            return new UtenteNegoziDTO
            {
                Utn_ID = entity.Utn_ID,
                Utn_IDNegozio = entity.Utn_IDNegozio,
                Utn_Annullato = entity.Utn_Annullato
            };
        }

        private DbUtenteNegozi MapToEntity(UtenteNegoziDTO dto)
        {
            if (dto == null) return null;
            return new DbUtenteNegozi
            {
                Utn_ID = dto.Utn_ID,
                Utn_IDNegozio = dto.Utn_IDNegozio,
                Utn_Annullato = dto.Utn_Annullato
            };
        }
    }
}