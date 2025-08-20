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
    public class StatoRegioniService : IStatoRegioniService
    {
        private readonly IStatoRegioniRepository _repository;

        public StatoRegioniService(IStatoRegioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<StatoRegioniDTO>> GetAllAsync(StatoRegioniListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<StatoRegioniDTO>(items, total);
        }

        public async Task<StatoRegioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<StatoRegioniDTO> AddAsync(StatoRegioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<StatoRegioniDTO> UpdateAsync(StatoRegioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Str_IDAuto);
            if (entity == null) return null;

            entity.Str_Descrizione = dto.Str_Descrizione;
            entity.Str_CodCapoluogo = dto.Str_CodCapoluogo;
            entity.Str_ISO1 = dto.Str_ISO1;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private StatoRegioniDTO MapToDto(DbStatoRegioni entity)
        {
            return new StatoRegioniDTO
            {
                Str_ISO1 = entity.Str_ISO1,
                Str_IDAuto = entity.Str_IDAuto,
                Str_Descrizione = entity.Str_Descrizione,
                Str_CodCapoluogo = entity.Str_CodCapoluogo,
                IdStatoRegioni = entity.IdStatoRegioni.Select(idReg => new IdStatoRegioniDTO
                {
                    Strid_ISONum = idReg.Strid_ISONum,
                    Strid_ID = idReg.Strid_ID,
                    Strid_Descrizione = idReg.Strid_Descrizione
                }).ToList()
            };
        }

        private DbStatoRegioni MapToEntity(StatoRegioniDTO dto)
        {
            return new DbStatoRegioni
            {
                Str_ISO1 = dto.Str_ISO1,
                Str_IDAuto = dto.Str_IDAuto,
                Str_Descrizione = dto.Str_Descrizione,
                Str_CodCapoluogo = dto.Str_CodCapoluogo,
                IdStatoRegioni = dto.IdStatoRegioni.Select(idDto => new DbIdStatoRegioni
                {
                    Strid_ISONum = idDto.Strid_ISONum,
                    Strid_ID = idDto.Strid_ID,
                    Strid_Descrizione = idDto.Strid_Descrizione
                }).ToList()
            };
        }
    }
}