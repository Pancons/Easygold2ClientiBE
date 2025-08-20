using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class CausaliService : ICausaliService
    {
        private readonly ICausaliRepository _repository;

        public CausaliService(ICausaliRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CausaliDTO>> GetAllAsync(CausaliListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<CausaliDTO>(dtos, total);
        }

        public async Task<CausaliDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CausaliDTO> AddAsync(CausaliDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<CausaliDTO> UpdateAsync(CausaliDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Cal_IDAuto, language);
            if (entity == null) return null;

            entity.Cal_Descrizione = dto.Cal_Descrizione;
            entity.Cal_IDDoveUso = dto.Cal_IDDoveUso;
            entity.Cal_IDProgressivo = dto.Cal_IDProgressivo;
            entity.Cal_IDTipoAnagrafica = dto.Cal_IDtipoAnagrafica;
            entity.Cal_IDTipoIVA = dto.Cal_IDtipoIVA;
            entity.Cal_Annulla = dto.Cal_Annulla;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CausaliDTO MapToDto(DbCausali entity)
        {
            return new CausaliDTO
            {
                Cal_IDAuto = entity.Cal_IDAuto,
                Cal_Descrizione = entity.Cal_Descrizione,
                Cal_IDDoveUso = entity.Cal_IDDoveUso,
                Cal_IDProgressivo = entity.Cal_IDProgressivo,
                Cal_IDtipoAnagrafica = entity.Cal_IDTipoAnagrafica,
                Cal_IDtipoIVA = entity.Cal_IDTipoIVA,
                Cal_Annulla = entity.Cal_Annulla,
                CausaliLang = entity.CausaliLang.Select(cl => new CausaliLangDTO
                {
                    // Map fields from DbCausaliLang to CausaliLangDTO
                }).ToList()
            };
        }

        private DbCausali MapToEntity(CausaliDTO dto)
        {
            return new DbCausali
            {
                Cal_IDAuto = dto.Cal_IDAuto,
                Cal_Descrizione = dto.Cal_Descrizione,
                Cal_IDDoveUso = dto.Cal_IDDoveUso,
                Cal_IDProgressivo = dto.Cal_IDProgressivo,
                Cal_IDTipoAnagrafica = dto.Cal_IDtipoAnagrafica,
                Cal_IDTipoIVA = dto.Cal_IDtipoIVA,
                Cal_Annulla = dto.Cal_Annulla
                // Map additional necessary properties or relationships
            };
        }
    }
}