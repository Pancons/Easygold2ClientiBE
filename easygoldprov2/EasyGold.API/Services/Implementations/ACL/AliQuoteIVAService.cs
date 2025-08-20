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
    public class AliQuoteIVAService : IAliQuoteIVAService
    {
        private readonly IAliQuoteIVARepository _repository;

        public AliQuoteIVAService(IAliQuoteIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<AliQuoteIVADTO>> GetAllAsync(AliQuoteIVAListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<AliQuoteIVADTO>(dtos, total);
        }

        public async Task<AliQuoteIVADTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<AliQuoteIVADTO> AddAsync(AliQuoteIVADTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<AliQuoteIVADTO> UpdateAsync(AliQuoteIVADTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Iva_IDAuto, language);
            if (entity == null) return null;

            entity.Iva_Descrizione = dto.Iva_Descrizione;
            entity.Iva_Aliquota = dto.Iva_Aliquota;
            entity.Iva_Esenzione = dto.Iva_Esenzione;
            entity.Iva_Scorporata = dto.Iva_Scorporata;
            entity.Iva_Annullato = dto.Iva_Annullato;
            entity.Iva_Estero = dto.Iva_Estero;
            entity.Iva_NaturaFE = dto.Iva_NaturaFE;
            entity.Iva_NaturaSC = dto.Iva_NaturaSC;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private AliQuoteIVADTO MapToDto(DbAliQuoteIVA entity)
        {
            return new AliQuoteIVADTO
            {
                Iva_IDAuto = entity.Iva_IDAuto,
                Iva_Descrizione = entity.Iva_Descrizione,
                Iva_Aliquota = entity.Iva_Aliquota,
                Iva_Esenzione = entity.Iva_Esenzione,
                Iva_Scorporata = entity.Iva_Scorporata,
                Iva_Annullato = entity.Iva_Annullato,
                Iva_Estero = entity.Iva_Estero,
                Iva_NaturaFE = entity.Iva_NaturaFE,
                Iva_NaturaSC = entity.Iva_NaturaSC,
                AliQuoteIVALang = entity.AliQuoteIVALang.Select(lang => new AliQuoteIVALangDTO
                {
                    Ivaid_ISONum = lang.Ivaid_ISONum,
                    Ivaid_ID = lang.Ivaid_ID,
                    Ivaid_Descrizione = lang.Ivaid_Descrizione
                }).ToList()
            };
        }

        private DbAliQuoteIVA MapToEntity(AliQuoteIVADTO dto)
        {
            return new DbAliQuoteIVA
            {
                Iva_IDAuto = dto.Iva_IDAuto,
                Iva_Descrizione = dto.Iva_Descrizione,
                Iva_Aliquota = dto.Iva_Aliquota,
                Iva_Esenzione = dto.Iva_Esenzione,
                Iva_Scorporata = dto.Iva_Scorporata,
                Iva_Annullato = dto.Iva_Annullato,
                Iva_Estero = dto.Iva_Estero,
                Iva_NaturaFE = dto.Iva_NaturaFE,
                Iva_NaturaSC = dto.Iva_NaturaSC,
                AliQuoteIVALang = dto.AliQuoteIVALang.Select(langDto => new DbAliQuoteIVALang
                {
                    Ivaid_ISONum = langDto.Ivaid_ISONum,
                    Ivaid_ID = langDto.Ivaid_ID,
                    Ivaid_Descrizione = langDto.Ivaid_Descrizione
                }).ToList()
            };
        }
    }
}