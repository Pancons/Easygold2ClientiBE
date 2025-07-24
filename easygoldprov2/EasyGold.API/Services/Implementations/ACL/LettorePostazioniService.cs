using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class LettorePostazioniService : ILettorePostazioniService
    {
        private readonly ILettorePostazioniRepository _repository;

        public LettorePostazioniService(ILettorePostazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<LettorePostazioniDTO>> GetAllAsync(LettorePostazioniListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<LettorePostazioniDTO>(dtos, total);
        }

        public async Task<LettorePostazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<LettorePostazioniDTO> AddAsync(LettorePostazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<LettorePostazioniDTO> UpdateAsync(LettorePostazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Lpo_IDAuto);
            if (entity == null) return null;

            entity.Lpo_IDPostazione = dto.Lpo_IDPostazione;
            entity.Lpo_IDLettore = dto.Lpo_IDLettore;
            entity.Lpo_DevLettore = dto.Lpo_DevLettore;
            entity.Lpo_Annullato = dto.Lpo_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private LettorePostazioniDTO MapToDto(DbLettorePostazioni entity)
        {
            return new LettorePostazioniDTO
            {
                Lpo_IDAuto = entity.Lpo_IDAuto,
                Lpo_IDPostazione = entity.Lpo_IDPostazione,
                Lpo_IDLettore = entity.Lpo_IDLettore,
                Lpo_DevLettore = entity.Lpo_DevLettore,
                Lpo_Annullato = entity.Lpo_Annullato
            };
        }

        private DbLettorePostazioni MapToEntity(LettorePostazioniDTO dto)
        {
            return new DbLettorePostazioni
            {
                Lpo_IDAuto = dto.Lpo_IDAuto,
                Lpo_IDPostazione = dto.Lpo_IDPostazione,
                Lpo_IDLettore = dto.Lpo_IDLettore,
                Lpo_DevLettore = dto.Lpo_DevLettore,
                Lpo_Annullato = dto.Lpo_Annullato
            };
        }
    }
}