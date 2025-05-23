using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.Prodotti;

namespace EasyGold.API.Services.Implementations.Prodotti
{
    public class ListiniProdottoLangService : IListiniProdottoLangService
    {
        private readonly IListiniProdottoLangRepository _repository;

        public ListiniProdottoLangService(IListiniProdottoLangRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ListiniProdottoLangDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ListiniProdottoLangDTO>(list, list.Count);
        }

        public async Task<ListiniProdottoLangDTO> GetByIdAsync(int lisidISONum, int lisidID)
        {
            var entity = await _repository.GetByIdAsync(lisidISONum, lisidID);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ListiniProdottoLangDTO> AddAsync(ListiniProdottoLangDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<ListiniProdottoLangDTO> UpdateAsync(ListiniProdottoLangDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Lisid_ISONum, dto.Lisid_ID);
            if (entity == null) return null;

            entity.Lisid_Descrizione = dto.Lisid_Descrizione;
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int lisidISONum, int lisidID)
        {
            await _repository.DeleteAsync(lisidISONum, lisidID);
        }

        // --- Mapping manuale ---

        private ListiniProdottoLangDTO MapToDto(DbListiniProdottoLang entity)
        {
            if (entity == null) return null;
            return new ListiniProdottoLangDTO
            {
                Lisid_ISONum = entity.Lisid_ISONum,
                Lisid_ID = entity.Lisid_ID,
                Lisid_Descrizione = entity.Lisid_Descrizione
            };
        }

        private DbListiniProdottoLang MapToEntity(ListiniProdottoLangDTO dto)
        {
            if (dto == null) return null;
            return new DbListiniProdottoLang
            {
                Lisid_ISONum = dto.Lisid_ISONum,
                Lisid_ID = dto.Lisid_ID,
                Lisid_Descrizione = dto.Lisid_Descrizione
            };
        }
    }
}