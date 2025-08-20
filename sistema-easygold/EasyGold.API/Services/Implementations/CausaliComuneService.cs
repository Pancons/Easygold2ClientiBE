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
    public class CausaliComuneService : ICausaliComuneService
    {
        private readonly ICausaliComuneRepository _repository;

        public CausaliComuneService(ICausaliComuneRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CausaliComuneDTO>> GetAllAsync(CausaliComuneListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<CausaliComuneDTO>(dtos, total);
        }

        public async Task<CausaliComuneDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CausaliComuneDTO> AddAsync(CausaliComuneDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CausaliComuneDTO> UpdateAsync(CausaliComuneDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Cac_IDAuto, language);
            if (entity == null) return null;

            entity.Cac_Descrizione = dto.Cac_Descrizione;
            entity.Cac_IDDoveUso = dto.Cac_IDDoveUso;
            entity.Cac_IDProgressivo = dto.Cac_IDProgressivo;
            entity.Cac_IDTipoAnagrafica = dto.Cac_IDtipoAnagrafica;
            entity.Cac_IDTipoIVA = dto.Cac_IDtipoIVA;
            entity.Cac_Annulla = dto.Cac_Annulla;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CausaliComuneDTO MapToDto(DbCausaliComune entity)
        {
            return new CausaliComuneDTO
            {
                Cac_IDAuto = entity.Cac_IDAuto,
                Cac_Descrizione = entity.Cac_Descrizione,
                Cac_IDDoveUso = entity.Cac_IDDoveUso,
                Cac_IDProgressivo = entity.Cac_IDProgressivo,
                Cac_IDtipoAnagrafica = entity.Cac_IDTipoAnagrafica,
                Cac_IDtipoIVA = entity.Cac_IDTipoIVA,
                Cac_Annulla = entity.Cac_Annulla,
                // Map additional fields if necessary
            };
        }

        private DbCausaliComune MapToEntity(CausaliComuneDTO dto)
        {
            return new DbCausaliComune
            {
                Cac_IDAuto = dto.Cac_IDAuto,
                Cac_Descrizione = dto.Cac_Descrizione,
                Cac_IDDoveUso = dto.Cac_IDDoveUso,
                Cac_IDProgressivo = dto.Cac_IDProgressivo,
                Cac_IDTipoAnagrafica = dto.Cac_IDtipoAnagrafica,
                Cac_IDTipoIVA = dto.Cac_IDtipoIVA,
                Cac_Annulla = dto.Cac_Annulla,
                // Map additional fields if necessary
            };
        }
    }
}