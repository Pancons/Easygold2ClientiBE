using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class LocalitaService : ILocalitaService
    {
        private readonly ILocalitaRepository _repository;

        public LocalitaService(ILocalitaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<LocalitaDTO>> GetAllAsync(LocalitaListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<LocalitaDTO>(dtos, total);
        }

        public async Task<LocalitaDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<LocalitaDTO> AddAsync(LocalitaDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<LocalitaDTO> UpdateAsync(LocalitaDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Str_IDAuto, language);
            if (entity == null) return null;

            entity.Str_Descrizione = dto.Str_Descrizione;
            entity.Str_CodStatoRegione = dto.Str_CodStatoRegione;
            entity.Str_CodProvincia = dto.Str_CodProvincia;
            entity.Str_CAP = dto.Str_CAP;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private LocalitaDTO MapToDto(DbLocalita entity)
        {
            return new LocalitaDTO
            {
                Str_ISO1 = entity.Str_ISO1,
                Str_IDAuto = entity.Str_IDAuto,
                Str_Descrizione = entity.Str_Descrizione,
                Str_CodStatoRegione = entity.Str_CodStatoRegione,
                Str_CodProvincia = entity.Str_CodProvincia,
                Str_CAP = entity.Str_CAP,
                Traduzioni = entity.LocalitaLang.Select(lang => new LocalitaLangDTO
                {
                    Strid_ISONum = lang.Strid_ISONum,
                    Strid_ID = lang.Strid_ID,
                    Strid_Descrizione = lang.Strid_Descrizione
                }).ToList()
            };
        }

        private DbLocalita MapToEntity(LocalitaDTO dto)
        {
            return new DbLocalita
            {
                Str_ISO1 = dto.Str_ISO1,
                Str_IDAuto = dto.Str_IDAuto,
                Str_Descrizione = dto.Str_Descrizione,
                Str_CodStatoRegione = dto.Str_CodStatoRegione,
                Str_CodProvincia = dto.Str_CodProvincia,
                Str_CAP = dto.Str_CAP
                // Assume una funzione separata gestisce la mapping delle traduzioni linguistiche
            };
        }
    }
}