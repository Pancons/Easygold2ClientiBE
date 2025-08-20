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
    public class ImpFinanziarieService : IImpFinanziarieService
    {
        private readonly IImpFinanziarieRepository _repository;

        public ImpFinanziarieService(IImpFinanziarieRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ImpFinanziarieDTO>> GetAllAsync(ImpFinanziarieListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ImpFinanziarieDTO>(dtos, total);
        }

        public async Task<ImpFinanziarieDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ImpFinanziarieDTO> AddAsync(ImpFinanziarieDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ImpFinanziarieDTO> UpdateAsync(ImpFinanziarieDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Imf_IDAuto, language);
            if (entity == null) return null;

            entity.Imf_Descrizione = dto.Imf_Descrizione;
            entity.Imf_IBAN = dto.Imf_IBAN;
            entity.Imf_BIC = dto.Imf_BIC;
            entity.Imf_Annullato = dto.Imf_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ImpFinanziarieDTO MapToDto(DbImpFinanziarie entity)
        {
            return new ImpFinanziarieDTO
            {
                Imf_IDAuto = entity.Imf_IDAuto,
                Imf_Descrizione = entity.Imf_Descrizione,
                Imf_IBAN = entity.Imf_IBAN,
                Imf_BIC = entity.Imf_BIC,
                Imf_Annullato = entity.Imf_Annullato,
                // Gestisci i campi specifici per la lingua da ImpFinanziarieLang
            };
        }

        private DbImpFinanziarie MapToEntity(ImpFinanziarieDTO dto)
        {
            return new DbImpFinanziarie
            {
                Imf_IDAuto = dto.Imf_IDAuto,
                Imf_Descrizione = dto.Imf_Descrizione,
                Imf_IBAN = dto.Imf_IBAN,
                Imf_BIC = dto.Imf_BIC,
                Imf_Annullato = dto.Imf_Annullato,
                // Gestisci eventuali relazioni necessarie
            };
        }
    }
}