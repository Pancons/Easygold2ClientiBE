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
    public class NegoziService : INegoziService
    {
        private readonly INegoziRepository _repository;

        public NegoziService(INegoziRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NegoziDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NegoziDTO>(list, list.Count);
        }

        public async Task<NegoziDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NegoziDTO> AddAsync(NegoziDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Neg_IDAuto = entity.Neg_IDAuto;
            return dto;
        }

        public async Task<NegoziDTO> UpdateAsync(NegoziDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Neg_IDAuto);
            if (entity == null) return null;

            entity.Neg_IDRagSociale = dto.Neg_IDRagSociale;
            entity.Neg_Virtuale = dto.Neg_Virtuale;
            entity.Neg_Nome = dto.Neg_Nome;
            entity.Neg_Indirizzo = dto.Neg_Indirizzo;
            entity.Neg_CAP = dto.Neg_CAP;
            entity.Neg_Localita = dto.Neg_Localita;
            entity.Neg_Provincia = dto.Neg_Provincia;
            entity.Neg_StatoRegione = dto.Neg_StatoRegione;
            entity.Neg_Telefono = dto.Neg_Telefono;
            entity.Neg_Email = dto.Neg_Email;
            entity.Neg_Default = dto.Neg_Default;
            entity.Neg_Annullato = dto.Neg_Annullato;
            entity.Neg_SolaVisualizzazione = dto.Neg_SolaVisualizzazione;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NegoziDTO MapToDto(DbNegozi entity)
        {
            if (entity == null) return null;
            return new NegoziDTO
            {
                Neg_IDAuto = entity.Neg_IDAuto,
                Neg_IDRagSociale = entity.Neg_IDRagSociale,
                Neg_Virtuale = entity.Neg_Virtuale,
                Neg_Nome = entity.Neg_Nome,
                Neg_Indirizzo = entity.Neg_Indirizzo,
                Neg_CAP = entity.Neg_CAP,
                Neg_Localita = entity.Neg_Localita,
                Neg_Provincia = entity.Neg_Provincia,
                Neg_StatoRegione = entity.Neg_StatoRegione,
                Neg_Telefono = entity.Neg_Telefono,
                Neg_Email = entity.Neg_Email,
                Neg_Default = entity.Neg_Default,
                Neg_Annullato = entity.Neg_Annullato,
                Neg_SolaVisualizzazione = entity.Neg_SolaVisualizzazione
            };
        }

        private DbNegozi MapToEntity(NegoziDTO dto)
        {
            if (dto == null) return null;
            return new DbNegozi
            {
                Neg_IDAuto = dto.Neg_IDAuto,
                Neg_IDRagSociale = dto.Neg_IDRagSociale,
                Neg_Virtuale = dto.Neg_Virtuale,
                Neg_Nome = dto.Neg_Nome,
                Neg_Indirizzo = dto.Neg_Indirizzo,
                Neg_CAP = dto.Neg_CAP,
                Neg_Localita = dto.Neg_Localita,
                Neg_Provincia = dto.Neg_Provincia,
                Neg_StatoRegione = dto.Neg_StatoRegione,
                Neg_Telefono = dto.Neg_Telefono,
                Neg_Email = dto.Neg_Email,
                Neg_Default = dto.Neg_Default,
                Neg_Annullato = dto.Neg_Annullato,
                Neg_SolaVisualizzazione = dto.Neg_SolaVisualizzazione
            };
        }
    }
}