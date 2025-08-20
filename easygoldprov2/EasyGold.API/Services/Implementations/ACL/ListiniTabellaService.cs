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
    public class ListiniTabellaService : IListiniTabellaService
    {
        private readonly IListiniTabellaRepository _repository;

        public ListiniTabellaService(IListiniTabellaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ListiniTabellaDTO>> GetAllAsync(ListiniTabellaListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<ListiniTabellaDTO>(dtos, total);
        }

        public async Task<ListiniTabellaDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ListiniTabellaDTO> AddAsync(ListiniTabellaDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ListiniTabellaDTO> UpdateAsync(ListiniTabellaDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Lst_IDAuto, "en");
            if (entity == null) return null;

            entity.Lst_Descrizione = dto.Lst_Descrizione;
            entity.Lst_TipoCalcolo = dto.Lst_TipoCalcolo;
            entity.Lst_PrezzoGrammo = dto.Lst_PrezzoGrammo;
            entity.Lst_Moltiplicatore = dto.Lst_Moltiplicatore;
            entity.Lst_MoltipManifattura = dto.Lst_MoltipManifattura;
            entity.Lst_Annullato = dto.Lst_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ListiniTabellaDTO MapToDto(DbListiniTabella entity)
        {
            return new ListiniTabellaDTO
            {
                Lst_IDAuto = entity.Lst_IDAuto,
                Lst_Descrizione = entity.Lst_Descrizione,
                Lst_TipoCalcolo = entity.Lst_TipoCalcolo,
                Lst_PrezzoGrammo = entity.Lst_PrezzoGrammo,
                Lst_Moltiplicatore = entity.Lst_Moltiplicatore,
                Lst_MoltipManifattura = entity.Lst_MoltipManifattura,
                Lst_Annullato = entity.Lst_Annullato,
                // Altre proprietà mappate se necessario
            };
        }

        private DbListiniTabella MapToEntity(ListiniTabellaDTO dto)
        {
            return new DbListiniTabella
            {
                Lst_IDAuto = dto.Lst_IDAuto,
                Lst_Descrizione = dto.Lst_Descrizione,
                Lst_TipoCalcolo = dto.Lst_TipoCalcolo,
                Lst_PrezzoGrammo = dto.Lst_PrezzoGrammo,
                Lst_Moltiplicatore = dto.Lst_Moltiplicatore,
                Lst_MoltipManifattura = dto.Lst_MoltipManifattura,
                Lst_Annullato = dto.Lst_Annullato,
                // Map qualsiasi proprietà o relazione necessaria
            };
        }
    }
}