using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class TagProdottiService : ITagProdottiService
    {
        private readonly ITagProdottiRepository _repository;

        public TagProdottiService(ITagProdottiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TagProdottiDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(TagProdottiDTO.Etp_Descrizione))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Etp_Descrizione)
                            : entities.OrderBy(e => e.Etp_Descrizione);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<TagProdottiDTO>(dtos, total);
        }

        public async Task<TagProdottiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<TagProdottiDTO> AddAsync(TagProdottiDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<TagProdottiDTO> UpdateAsync(TagProdottiDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static TagProdottiDTO ToDTO(DbTagProdotti e) => new TagProdottiDTO
        {
            Etp_IDAuto = e.Etp_IDAuto,
            Etp_Descrizione = e.Etp_Descrizione,
            Etp_ColEtichetta = e.Etp_ColEtichetta,
            Etp_ColSfondo = e.Etp_ColSfondo,
            Etp_TipoEtichetta = e.Etp_TipoEtichetta,
            Etp_InEvidenza = e.Etp_InEvidenza,
            Etp_Annullato = e.Etp_Annullato
        };

        private static DbTagProdotti ToEntity(TagProdottiDTO dto) => new DbTagProdotti
        {
            Etp_IDAuto = dto.Etp_IDAuto ?? 0,
            Etp_Descrizione = dto.Etp_Descrizione,
            Etp_ColEtichetta = dto.Etp_ColEtichetta,
            Etp_ColSfondo = dto.Etp_ColSfondo,
            Etp_TipoEtichetta = dto.Etp_TipoEtichetta,
            Etp_InEvidenza = dto.Etp_InEvidenza,
            Etp_Annullato = dto.Etp_Annullato
        };
    }
}