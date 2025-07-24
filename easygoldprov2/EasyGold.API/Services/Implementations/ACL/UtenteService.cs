using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRepository _repository;

        public UtenteService(IUtenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<UtenteDTO>> GetAllAsync(BaseListRequest request)
        {
            var (users, total) = await _repository.GetAllAsync(request);
            var list = users.Select(MapToDto).ToList();
            return new BaseListResponse<UtenteDTO>(list, total);
        }

        public async Task<UtenteDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<UtenteDTO> AddAsync(UtenteDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Ute_IDAuto = entity.Ute_IDAuto;
            return dto;
        }

        public async Task<UtenteDTO> UpdateAsync(UtenteDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Ute_IDAuto);
            if (entity == null) return null;

            entity.Ute_IDUtente = dto.Ute_IDUtente;
            entity.Ute_NomeUtente = dto.Ute_NomeUtente;
            entity.Ute_IDGruppo = dto.Ute_IDGruppo;
            entity.Ute_IDIdioma = dto.Ute_IDIdioma;
            entity.Ute_AbilitaTuttiNegozi = dto.Ute_AbilitaTuttiNegozi;
            entity.Ute_AbilitaCassa = dto.Ute_AbilitaCassa;
            entity.Ute_AbilitaEliminaProd = dto.Ute_AbilitaEliminaProd;
            entity.Ute_Bloccato = dto.Ute_Bloccato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private UtenteDTO MapToDto(DbUtente entity)
        {
            if (entity == null) return null;
            return new UtenteDTO
            {
                Ute_IDAuto = entity.Ute_IDAuto,
                Ute_IDUtente = entity.Ute_IDUtente,
                Ute_NomeUtente = entity.Ute_NomeUtente,
                Ute_IDGruppo = entity.Ute_IDGruppo,
                Ute_IDIdioma = entity.Ute_IDIdioma,
                Ute_AbilitaTuttiNegozi = entity.Ute_AbilitaTuttiNegozi,
                Ute_AbilitaCassa = entity.Ute_AbilitaCassa,
                Ute_AbilitaEliminaProd = entity.Ute_AbilitaEliminaProd,
                Ute_Bloccato = entity.Ute_Bloccato
            };
        }

        private DbUtente MapToEntity(UtenteDTO dto)
        {
            if (dto == null) return null;
            return new DbUtente
            {
                Ute_IDAuto = dto.Ute_IDAuto,
                Ute_IDUtente = dto.Ute_IDUtente,
                Ute_NomeUtente = dto.Ute_NomeUtente,
                Ute_IDGruppo = dto.Ute_IDGruppo,
                Ute_IDIdioma = dto.Ute_IDIdioma,
                Ute_AbilitaTuttiNegozi = dto.Ute_AbilitaTuttiNegozi,
                Ute_AbilitaCassa = dto.Ute_AbilitaCassa,
                Ute_AbilitaEliminaProd = dto.Ute_AbilitaEliminaProd,
                Ute_Bloccato = dto.Ute_Bloccato
            };
        }
    }
}