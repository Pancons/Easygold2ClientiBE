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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _repository;

        public ProvinceService(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ProvinceDTO>> GetAllAsync(ProvinceListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();

            return new BaseListResponse<ProvinceDTO>(dtos, total);
        }

        public async Task<ProvinceDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ProvinceDTO> AddAsync(ProvinceDTO dto, string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task<ProvinceDTO> UpdateAsync(ProvinceDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Str_IDAuto, language);
            if (entity == null) return null;

            entity.Str_Descrizione = dto.Str_Descrizione;
            entity.Str_SiglaTargaAuto = dto.Str_SiglaTargaAuto;
            entity.Str_CodStatoRegione = dto.Str_CodStatoRegione;

            await _repository.UpdateAsync(entity, language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ProvinceDTO MapToDto(DbProvince entity)
        {
            return new ProvinceDTO
            {
                Str_IDAuto = entity.Str_IDAuto,
                Str_Descrizione = entity.Str_Descrizione,
                Str_SiglaTargaAuto = entity.Str_SiglaTargaAuto,
                Str_CodStatoRegione = entity.Str_CodStatoRegione
                // Consider adding language-specific mapping here
            };
        }

        private DbProvince MapToEntity(ProvinceDTO dto)
        {
            return new DbProvince
            {
                Str_IDAuto = dto.Str_IDAuto,
                Str_Descrizione = dto.Str_Descrizione,
                Str_SiglaTargaAuto = dto.Str_SiglaTargaAuto,
                Str_CodStatoRegione = dto.Str_CodStatoRegione
                // Add other necessary mappings if any
            };
        }
    }
}