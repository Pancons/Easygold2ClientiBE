using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class RegFiscaleService : IRegFiscaleService
    {
        private readonly IRegFiscaleRepository _repository;

        public RegFiscaleService(IRegFiscaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<RegFiscaleDTO>> GetAllAsync(RegFiscaleListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            return new BaseListResponse<RegFiscaleDTO>(entities.Select(MapToDto), total);
        }

        public async Task<RegFiscaleDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<RegFiscaleDTO> AddAsync(RegFiscaleDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<RegFiscaleDTO> UpdateAsync(RegFiscaleDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Rfi_IDAuto);
            if (entity == null) return null;
       
            entity.Rfi_Descrizione = dto.Rfi_Descrizione;
            entity.Rfi_TipoRegFiscale = dto.Rfi_TipoRegFiscale;
            entity.Rfi_CodNegozio = dto.Rfi_CodNegozio;
            entity.Rfi_Matricola = dto.Rfi_Matricola;
            entity.Rfi_NumeroChiusure = dto.Rfi_NumeroChiusure;
            entity.Rfi_UltimaDataChiusura = dto.Rfi_UltimaDataChiusura;
            entity.Rfi_Annullato = dto.Rfi_Annullato;
          
            await _repository.UpdateAsync(entity);   // Update entity fields from DTO
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private RegFiscaleDTO MapToDto(DbRegFiscale entity)
        {
            return new RegFiscaleDTO
            {
                Rfi_IDAuto = entity.Rfi_IDAuto,
                Rfi_Descrizione = entity.Rfi_Descrizione,
                Rfi_TipoRegFiscale = entity.Rfi_TipoRegFiscale,
                Rfi_CodNegozio = entity.Rfi_CodNegozio,
                Rfi_Matricola = entity.Rfi_Matricola,
                Rfi_NumeroChiusure = entity.Rfi_NumeroChiusure,
                Rfi_UltimaDataChiusura = entity.Rfi_UltimaDataChiusura,
                Rfi_Annullato = entity.Rfi_Annullato
            };
        }

        private DbRegFiscale MapToEntity(RegFiscaleDTO dto)
        {
            return new DbRegFiscale
            {
                Rfi_IDAuto = dto.Rfi_IDAuto,
                Rfi_Descrizione = dto.Rfi_Descrizione,
                Rfi_TipoRegFiscale = dto.Rfi_TipoRegFiscale,
                Rfi_CodNegozio = dto.Rfi_CodNegozio,
                Rfi_Matricola = dto.Rfi_Matricola,
                Rfi_NumeroChiusure = dto.Rfi_NumeroChiusure,
                Rfi_UltimaDataChiusura = dto.Rfi_UltimaDataChiusura,
                Rfi_Annullato = dto.Rfi_Annullato
            };
        }
    }
}