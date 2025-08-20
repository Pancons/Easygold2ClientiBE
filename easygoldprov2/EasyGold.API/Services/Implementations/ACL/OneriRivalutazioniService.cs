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
    public class OneriRivalutazioniService : IOneriRivalutazioniService
    {
        private readonly IOneriRivalutazioniRepository _repository;

        public OneriRivalutazioniService(IOneriRivalutazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<OneriRivalutazioniDTO>> GetAllAsync(OneriRivalutazioniListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<OneriRivalutazioniDTO>(dtos, total);
        }

        public async Task<OneriRivalutazioniDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<OneriRivalutazioniDTO> AddAsync(OneriRivalutazioniDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<OneriRivalutazioniDTO> UpdateAsync(OneriRivalutazioniDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Onr_IDAuto, language);
            if (entity == null) return null;

            entity.Onr_Modifica = dto.Onr_Modifica;
            entity.Onr_Fee = dto.Onr_Fee;
            entity.Onr_Ordinamento = dto.Onr_Ordinamento;
            entity.Onr_Annulla = dto.Onr_Annulla;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private OneriRivalutazioniDTO MapToDto(DbOneriRivalutazioni entity)
        {
            return new OneriRivalutazioniDTO
            {
                Onr_IDAuto = entity.Onr_IDAuto,
                Onr_Modifica = entity.Onr_Modifica,
                Onr_Fee = entity.Onr_Fee,
                Onr_Ordinamento = entity.Onr_Ordinamento,
                Onr_Annulla = entity.Onr_Annulla,
                Lingue = entity.OneriRivalutazioniLang.Select(lang => new OneriRivalutazioniLangDTO
                {
                    OnrId_ISONum = lang.OnrId_ISONum,
                    OnrId_ID = lang.OnrId_ID,
                    OnrId_Descrizione = lang.OnrId_Descrizione
                }).ToList()
            };
        }

        private DbOneriRivalutazioni MapToEntity(OneriRivalutazioniDTO dto)
        {
            return new DbOneriRivalutazioni
            {
                Onr_IDAuto = dto.Onr_IDAuto,
                Onr_Modifica = dto.Onr_Modifica,
                Onr_Fee = dto.Onr_Fee,
                Onr_Ordinamento = dto.Onr_Ordinamento,
                Onr_Annulla = dto.Onr_Annulla
            };
        }
    }
}