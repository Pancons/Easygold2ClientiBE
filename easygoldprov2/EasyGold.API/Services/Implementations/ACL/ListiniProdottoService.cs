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
    public class ListiniProdottoService : IListiniProdottoService
    {
        private readonly IListiniProdottoRepository _repository;

        public ListiniProdottoService(IListiniProdottoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ListiniProdottoDTO>> GetAllAsync(ListiniProdottoListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<ListiniProdottoDTO>(dtos, total);
        }

        public async Task<ListiniProdottoDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ListiniProdottoDTO> AddAsync(ListiniProdottoDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ListiniProdottoDTO> UpdateAsync(ListiniProdottoDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Lis_IDAuto, language);
            if (entity == null) return null;

            entity.Lis_Descrizione = dto.Lis_Descrizione;
            entity.Lis_Valuta = dto.Lis_Valuta;
            entity.Lis_TipoListino = dto.Lis_TipoListino;
            entity.Lis_Default = dto.Lis_Default;
            entity.Lis_PercSconto = dto.Lis_PercSconto;
            entity.Lis_TipoArrotondamento = dto.Lis_TipoArrotondamento;
            entity.Lis_Arrotondamento = dto.Lis_Arrotondamento;
            entity.Lis_Annullato = dto.Lis_Annullato;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ListiniProdottoDTO MapToDto(DbListiniProdotto entity)
        {
            return new ListiniProdottoDTO
            {
                Lis_IDAuto = entity.Lis_IDAuto,
                Lis_Descrizione = entity.Lis_Descrizione,
                Lis_Valuta = entity.Lis_Valuta,
                Lis_TipoListino = entity.Lis_TipoListino,
                Lis_Default = entity.Lis_Default,
                Lis_PercSconto = entity.Lis_PercSconto,
                Lis_TipoArrotondamento = entity.Lis_TipoArrotondamento,
                Lis_Arrotondamento = entity.Lis_Arrotondamento,
                Lis_Annullato = entity.Lis_Annullato,
                ListiniProdottoLang = entity.ListiniProdottoLang.Select(lang => new ListiniProdottoLangDTO
                {
                    Lisid_ISONum = lang.Lisid_ISONum,
                    Lisid_ID = lang.Lisid_ID,
                    Lisid_Descrizione = lang.Lisid_Descrizione
                }).ToList()
            };
        }

        private DbListiniProdotto MapToEntity(ListiniProdottoDTO dto)
        {
            return new DbListiniProdotto
            {
                Lis_IDAuto = dto.Lis_IDAuto,
                Lis_Descrizione = dto.Lis_Descrizione,
                Lis_Valuta = dto.Lis_Valuta,
                Lis_TipoListino = dto.Lis_TipoListino,
                Lis_Default = dto.Lis_Default,
                Lis_PercSconto = dto.Lis_PercSconto,
                Lis_TipoArrotondamento = dto.Lis_TipoArrotondamento,
                Lis_Arrotondamento = dto.Lis_Arrotondamento,
                Lis_Annullato = dto.Lis_Annullato,
                ListiniProdottoLang = dto.ListiniProdottoLang.Select(lang => new DbListiniProdottoLang
                {
                    Lisid_ISONum = lang.Lisid_ISONum,
                    Lisid_ID = lang.Lisid_ID,
                    Lisid_Descrizione = lang.Lisid_Descrizione
                }).ToList()
            };
        }
    }
}