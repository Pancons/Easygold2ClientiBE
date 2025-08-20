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
    public class TagProdottiService : ITagProdottiService
    {
        private readonly ITagProdottiRepository _repository;

        public TagProdottiService(ITagProdottiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TagProdottiDTO>> GetAllAsync(TagProdottiListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<TagProdottiDTO>(dtos, total);
        }

        public async Task<TagProdottiDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TagProdottiDTO> AddAsync(TagProdottiDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<TagProdottiDTO> UpdateAsync(TagProdottiDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Etp_IDAuto, language);
            if (entity == null) return null;

            entity.Etp_Descrizione = dto.Etp_Descrizione;
            entity.Etp_Gruppo = dto.Etp_Gruppo;
            entity.Etp_ColEtichetta = dto.Etp_ColEtichetta;
            entity.Etp_ColSfondo = dto.Etp_ColSfondo;
            entity.Etp_TipoEtichetta = dto.Etp_TipoEtichetta;
            entity.Etp_DataScadenza = dto.Etp_DataScadenza;
            entity.Etp_InEvidenza = dto.Etp_InEvidenza;
            entity.Etp_Annullato = dto.Etp_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TagProdottiDTO MapToDto(DbTagProdotti entity)
        {
            return new TagProdottiDTO
            {
                Etp_IDAuto = entity.Etp_IDAuto,
                Etp_Descrizione = entity.Etp_Descrizione,
                Etp_Gruppo = entity.Etp_Gruppo,
                Etp_ColEtichetta = entity.Etp_ColEtichetta,
                Etp_ColSfondo = entity.Etp_ColSfondo,
                Etp_TipoEtichetta = entity.Etp_TipoEtichetta,
                Etp_DataScadenza = entity.Etp_DataScadenza,
                Etp_InEvidenza = entity.Etp_InEvidenza,
                Etp_Annullato = entity.Etp_Annullato,
            };
        }

        private DbTagProdotti MapToEntity(TagProdottiDTO dto)
        {
            return new DbTagProdotti
            {
                Etp_IDAuto = dto.Etp_IDAuto,
                Etp_Descrizione = dto.Etp_Descrizione,
                Etp_Gruppo = dto.Etp_Gruppo,
                Etp_ColEtichetta = dto.Etp_ColEtichetta,
                Etp_ColSfondo = dto.Etp_ColSfondo,
                Etp_TipoEtichetta = dto.Etp_TipoEtichetta,
                Etp_DataScadenza = dto.Etp_DataScadenza,
                Etp_InEvidenza = dto.Etp_InEvidenza,
                Etp_Annullato = dto.Etp_Annullato,
            };
        }
    }
}