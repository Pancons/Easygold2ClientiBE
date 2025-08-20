using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class CodPagamentoService : ICodPagamentoService
    {
        private readonly ICodPagamentoRepository _repository;

        public CodPagamentoService(ICodPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CodPagamentoDTO>> GetAllAsync(CodPagamentoListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<CodPagamentoDTO>(dtos, total);
        }

        public async Task<CodPagamentoDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CodPagamentoDTO> AddAsync(CodPagamentoDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CodPagamentoDTO> UpdateAsync(CodPagamentoDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Cpa_IDAuto, language);
            if (entity == null) return null;

            entity.Cpa_Descrizione = dto.Cpa_Descrizione;
            entity.Cpa_PartenzaMese = dto.Cpa_PartenzaMese;
            entity.Cpa_NumMesi = dto.Cpa_NumMesi;
            entity.Cpa_MeseCommerciale = dto.Cpa_MeseCommerciale;
            entity.Cpa_Annullato = dto.Cpa_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CodPagamentoDTO MapToDto(DbCodPagamento entity)
        {
            return new CodPagamentoDTO
            {
                Cpa_IDAuto = entity.Cpa_IDAuto,
                Cpa_Descrizione = entity.Cpa_Descrizione,
                Cpa_PartenzaMese = entity.Cpa_PartenzaMese,
                Cpa_NumMesi = entity.Cpa_NumMesi,
                Cpa_MeseCommerciale = entity.Cpa_MeseCommerciale,
                Cpa_Annullato = entity.Cpa_Annullato,
                Langs = entity.CodPagamentoLang.Select(lang => new CodPagamentoLangDTO
                {
                    CpaId_ISONum = lang.CpaId_ISONum,
                    CpaId_ID = lang.CpaId_ID,
                    CpaId_Descrizione = lang.CpaId_Descrizione
                }).ToList()
            };
        }

        private DbCodPagamento MapToEntity(CodPagamentoDTO dto)
        {
            return new DbCodPagamento
            {
                Cpa_IDAuto = dto.Cpa_IDAuto,
                Cpa_Descrizione = dto.Cpa_Descrizione,
                Cpa_PartenzaMese = dto.Cpa_PartenzaMese,
                Cpa_NumMesi = dto.Cpa_NumMesi,
                Cpa_MeseCommerciale = dto.Cpa_MeseCommerciale,
                Cpa_Annullato = dto.Cpa_Annullato,
            };
        }
    }
}