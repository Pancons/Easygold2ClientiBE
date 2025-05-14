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
    public class GruppiService : IGruppiService
    {
        private readonly IGruppiRepository _repository;

        public GruppiService(IGruppiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<GruppiDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(GruppiDTO.Gru_NomeGruppo))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Gru_NomeGruppo)
                            : entities.OrderBy(e => e.Gru_NomeGruppo);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<GruppiDTO>(dtos, total);
        }

        public async Task<GruppiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<GruppiDTO> AddAsync(GruppiDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<GruppiDTO> UpdateAsync(GruppiDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static GruppiDTO ToDTO(DbGruppi e) => new GruppiDTO
        {
            Gru_IDGruppo = e.Gru_IDGruppo,
            Gru_NomeGruppo = e.Gru_NomeGruppo,
            Gru_DescrizioneGruppo = e.Gru_DescrizioneGruppo,
            Gru_SuperAmministratore = e.Gru_SuperAmministratore,
            Gru_Bloccato = e.Gru_Bloccato
        };

        private static DbGruppi ToEntity(GruppiDTO dto) => new DbGruppi
        {
            Gru_IDGruppo = dto.Gru_IDGruppo ?? 0,
            Gru_NomeGruppo = dto.Gru_NomeGruppo,
            Gru_DescrizioneGruppo = dto.Gru_DescrizioneGruppo,
            Gru_SuperAmministratore = dto.Gru_SuperAmministratore,
            Gru_Bloccato = dto.Gru_Bloccato
        };
    }
}