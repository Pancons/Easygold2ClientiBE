using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class ListiniProdottoService : IListiniProdottoService
    {
        private readonly IListiniProdottoRepository _repository;

        public ListiniProdottoService(IListiniProdottoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ListiniProdottoDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ListiniProdottoDTO>(list, list.Count);
        }

        public async Task<ListiniProdottoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ListiniProdottoDTO> AddAsync(ListiniProdottoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Lis_IDAuto = entity.Lis_IDAuto;
            return dto;
        }

        public async Task<ListiniProdottoDTO> UpdateAsync(ListiniProdottoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Lis_IDAuto);
            if (entity == null) return null;

            entity.Lis_Descrizione = dto.Lis_Descrizione;
            entity.Lis_Valuta = dto.Lis_Valuta;
            entity.Lis_TipoListino = dto.Lis_TipoListino;
            entity.Lis_Default = dto.Lis_Default;
            entity.Lis_PercSconto = dto.Lis_PercSconto;
            entity.Lis_TipoArrotondamento = dto.Lis_TipoArrotondamento;
            entity.Lis_Arrotondamento = dto.Lis_Arrotondamento;
            entity.Lis_Annullato = dto.Lis_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // --- Mapping manuale ---

        private ListiniProdottoDTO MapToDto(DbListiniProdotto entity)
        {
            if (entity == null) return null;
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
                Lis_Annullato = entity.Lis_Annullato
            };
        }

        private DbListiniProdotto MapToEntity(ListiniProdottoDTO dto)
        {
            if (dto == null) return null;
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
                Lis_Annullato = dto.Lis_Annullato
            };
        }
    }
}