using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class ValuteService : IValuteService
    {
        private readonly IValuteRepository _repository;

        public ValuteService(IValuteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<ValuteDTO>(dtos, total);
        }

        public async Task<ValuteDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ValuteDTO> AddAsync(ValuteDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ValuteDTO> UpdateAsync(ValuteDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Val_IDAuto, language);
            if (entity == null) return null;

            entity.Val_Descrizione = dto.Val_Descrizione;
            entity.Val_Cambio = dto.Val_Cambio;
            entity.Val_NumDecimali = dto.Val_NumDecimali;
            entity.Val_SimboloValuta = dto.Val_SimboloValuta;
            entity.Val_SiglaValuta = dto.Val_SiglaValuta;
            entity.Val_Annullato = dto.Val_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ValuteDTO MapToDto(DbValute entity)
        {
            return new ValuteDTO
            {
                Val_IDAuto = entity.Val_IDAuto,
                Val_Descrizione = entity.Val_Descrizione,
                Val_Cambio = entity.Val_Cambio,
                Val_NumDecimali = entity.Val_NumDecimali,
                Val_SimboloValuta = entity.Val_SimboloValuta,
                Val_SiglaValuta = entity.Val_SiglaValuta,
                Val_Annullato = entity.Val_Annullato,
                ValuteLang = entity.ValuteLang.Select(vl => new ValuteLangDTO
                {
                    Valid_ISONum = vl.Valid_ISONum,
                    Valid_ID = vl.Valid_ID,
                    Valid_Descrizione = vl.Valid_Descrizione
                }).ToList()
            };
        }

        private DbValute MapToEntity(ValuteDTO dto)
        {
            return new DbValute
            {
                Val_IDAuto = dto.Val_IDAuto,
                Val_Descrizione = dto.Val_Descrizione,
                Val_Cambio = dto.Val_Cambio,
                Val_NumDecimali = dto.Val_NumDecimali,
                Val_SimboloValuta = dto.Val_SimboloValuta,
                Val_SiglaValuta = dto.Val_SiglaValuta,
                Val_Annullato = dto.Val_Annullato,
                ValuteLang = dto.ValuteLang.Select(vlDto => new DbValuteLang
                {
                    Valid_ISONum = vlDto.Valid_ISONum,
                    Valid_ID = vlDto.Valid_ID,
                    Valid_Descrizione = vlDto.Valid_Descrizione
                }).ToList()
            };
        }
    }
}