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
    public class NazioniMondoService : INazioniMondoService
    {
        private readonly INazioniMondoRepository _repository;

        public NazioniMondoService(INazioniMondoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NazioniMondoDTO>> GetAllAsync(NazioniMondoListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<NazioniMondoDTO>(dtos, total);
        }

        public async Task<NazioniMondoDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NazioniMondoDTO> AddAsync(NazioniMondoDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<NazioniMondoDTO> UpdateAsync(NazioniMondoDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Nzm_IDAuto, "en"); // Default to "en" if necessary here
            if (entity == null) return null;

            entity.Nzm_Nazione = dto.Nzm_Nazione;
            entity.Nzm_ISOAlfa2 = dto.Nzm_ISOAlfa2;
            entity.Nzm_ISOAlfa3 = dto.Nzm_ISOAlfa3;
            entity.Nzm_ISONum = dto.Nzm_ISONum;
            entity.Nzm_PrefTelefonico = dto.Nzm_PrefTelefonico;
            entity.Nzm_CapitaleIure = dto.Nzm_CapitaleIure;
            entity.Nzm_CapitaleFatto = dto.Nzm_CapitaleFatto;
            entity.Nzm_CapitaleAmm = dto.Nzm_CapitaleAmm;
            entity.Nzm_CapitaleIdioma = dto.Nzm_CapitaleIdioma;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NazioniMondoDTO MapToDto(DbNazioniMondo entity)
        {
            return new NazioniMondoDTO
            {
                Nzm_IDAuto = entity.Nzm_IDAuto,
                Nzm_Nazione = entity.Nzm_Nazione,
                Nzm_ISOAlfa2 = entity.Nzm_ISOAlfa2,
                Nzm_ISOAlfa3 = entity.Nzm_ISOAlfa3,
                Nzm_ISONum = entity.Nzm_ISONum,
                Nzm_PrefTelefonico = entity.Nzm_PrefTelefonico,
                Nzm_CapitaleIure = entity.Nzm_CapitaleIure,
                Nzm_CapitaleFatto = entity.Nzm_CapitaleFatto,
                Nzm_CapitaleAmm = entity.Nzm_CapitaleAmm,
                Nzm_CapitaleIdioma = entity.Nzm_CapitaleIdioma,
                // Map additional languages details if necessary
            };
        }

        private DbNazioniMondo MapToEntity(NazioniMondoDTO dto)
        {
            return new DbNazioniMondo
            {
                Nzm_IDAuto = dto.Nzm_IDAuto,
                Nzm_Nazione = dto.Nzm_Nazione,
                Nzm_ISOAlfa2 = dto.Nzm_ISOAlfa2,
                Nzm_ISOAlfa3 = dto.Nzm_ISOAlfa3,
                Nzm_ISONum = dto.Nzm_ISONum,
                Nzm_PrefTelefonico = dto.Nzm_PrefTelefonico,
                Nzm_CapitaleIure = dto.Nzm_CapitaleIure,
                Nzm_CapitaleFatto = dto.Nzm_CapitaleFatto,
                Nzm_CapitaleAmm = dto.Nzm_CapitaleAmm,
                Nzm_CapitaleIdioma = dto.Nzm_CapitaleIdioma,
                // Map additional languages details if necessary
            };
        }
    }
}