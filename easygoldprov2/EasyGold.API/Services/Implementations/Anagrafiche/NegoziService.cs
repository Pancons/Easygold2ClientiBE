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
    public class NegoziService : INegoziService
    {
        private readonly INegozioRepository _repository;

        public NegoziService(INegozioRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NegozioDTO>> GetAllAsync(NegozioListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NegozioDTO>(list, total);
        }

        public async Task<NegozioDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NegozioDTO> AddAsync(NegozioDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Neg_id = entity.Neg_id;
            return dto;
        }

        public async Task<NegozioDTO> UpdateAsync(NegozioDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Neg_id);
            if (entity == null) return null;

            entity.Neg_IDCliente = dto.Neg_IDCliente;
            entity.Neg_RagioneSociale = dto.Neg_RagioneSociale;
            entity.Neg_NomeNegozio = dto.Neg_NomeNegozio;
            entity.Neg_DataAttivazione = dto.Neg_DataAttivazione;
            entity.Neg_DataDisattivazione = dto.Neg_DataDisattivazione;
            entity.Neg_Bloccato = dto.Neg_Bloccato;
            entity.Neg_DataOraBlocco = dto.Neg_DataOraBlocco;
            entity.Neg_Note = dto.Neg_Note;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NegozioDTO MapToDto(DbNegozi entity)
        {
            return new NegozioDTO
            {
                Neg_IDCliente = entity.Neg_IDCliente,
                Neg_RagioneSociale = entity.Neg_RagioneSociale,
                Neg_NomeNegozio = entity.Neg_NomeNegozio,
                Neg_DataAttivazione = entity.Neg_DataAttivazione,
                Neg_DataDisattivazione = entity.Neg_DataDisattivazione,
                Neg_Bloccato = entity.Neg_Bloccato,
                Neg_DataOraBlocco = entity.Neg_DataOraBlocco,
                Neg_Note = entity.Neg_Note
            };
        }

        private DbNegozi MapToEntity(NegozioDTO dto)
        {
            return new DbNegozi
            {
                Neg_id = dto.Neg_id,
                Neg_IDCliente = dto.Neg_IDCliente,
                Neg_RagioneSociale = dto.Neg_RagioneSociale,
                Neg_NomeNegozio = dto.Neg_NomeNegozio,
                Neg_DataAttivazione = dto.Neg_DataAttivazione,
                Neg_DataDisattivazione = dto.Neg_DataDisattivazione,
                Neg_Bloccato = dto.Neg_Bloccato,
                Neg_DataOraBlocco = dto.Neg_DataOraBlocco,
                Neg_Note = dto.Neg_Note
            };
        }
    }
}