using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.Prodotti;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations.Prodotti
{
    public class TagProdottoService : ITagProdottoService
    {
        private readonly ITagProdottoRepository _repository;

        public TagProdottoService(ITagProdottoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TagProdottoDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<TagProdottoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TagProdottoDTO> AddAsync(TagProdottoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TagProdottoDTO> UpdateAsync(TagProdottoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Etp_IdAuto);
            if (entity == null) return null;

            entity.Etp_Descrizione = dto.Etp_Descrizione;
            entity.Etp_ColEtichetta = dto.Etp_ColEtichetta;
            entity.Etp_ColSfondo = dto.Etp_ColSfondo;
            entity.Etp_TipoEtichetta = dto.Etp_TipoEtichetta;
            entity.Etp_InEvidenza = dto.Etp_InEvidenza;
            entity.Etp_Annullato = dto.Etp_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private TagProdottoDTO MapToDto(DbTagProdotto entity)
        {
            return new TagProdottoDTO
            {
                Etp_IdAuto = entity.Etp_IdAuto,
                Etp_Descrizione = entity.Etp_Descrizione,
                Etp_ColEtichetta = entity.Etp_ColEtichetta,
                Etp_ColSfondo = entity.Etp_ColSfondo,
                Etp_TipoEtichetta = entity.Etp_TipoEtichetta,
                Etp_InEvidenza = entity.Etp_InEvidenza,
                Etp_Annullato = entity.Etp_Annullato
            };
        }

        private DbTagProdotto MapToEntity(TagProdottoDTO dto)
        {
            return new DbTagProdotto
            {
                Etp_IdAuto = dto.Etp_IdAuto,
                Etp_Descrizione = dto.Etp_Descrizione,
                Etp_ColEtichetta = dto.Etp_ColEtichetta,
                Etp_ColSfondo = dto.Etp_ColSfondo,
                Etp_TipoEtichetta = dto.Etp_TipoEtichetta,
                Etp_InEvidenza = dto.Etp_InEvidenza,
                Etp_Annullato = dto.Etp_Annullato
            };
        }
    }
}