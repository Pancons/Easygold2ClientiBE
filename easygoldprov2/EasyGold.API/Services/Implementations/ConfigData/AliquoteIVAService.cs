using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class AliquoteIVAService : IAliquoteIVAService
    {
        private readonly IAliquoteIVARepository _repository;

        public AliquoteIVAService(IAliquoteIVARepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<AliquoteIVADTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<AliquoteIVADTO>(list, list.Count);
        }

        public async Task<AliquoteIVADTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<AliquoteIVADTO> AddAsync(AliquoteIVADTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Iva_IDAuto = entity.Iva_IDAuto;
            return dto;
        }

        public async Task<AliquoteIVADTO> UpdateAsync(AliquoteIVADTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Iva_IDAuto);
            if (entity == null) return null;

            entity.Iva_Descrizione = dto.Iva_Descrizione;
            entity.Iva_Aliquota = dto.Iva_Aliquota;
            entity.Iva_Esenzione = dto.Iva_Esenzione;
            entity.Iva_Scorporata = dto.Iva_Scorporata;
            entity.Iva_Annullato = dto.Iva_Annullato;
            entity.Iva_Estero = dto.Iva_Estero;
            entity.Iva_NaturaFE = dto.Iva_NaturaFE;
            entity.Iva_NaturaSC = dto.Iva_NaturaSC;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private AliquoteIVADTO MapToDto(DbAliquoteIVA entity)
        {
            if (entity == null) return null;
            return new AliquoteIVADTO
            {
                Iva_IDAuto = entity.Iva_IDAuto,
                Iva_Descrizione = entity.Iva_Descrizione,
                Iva_Aliquota = entity.Iva_Aliquota,
                Iva_Esenzione = entity.Iva_Esenzione,
                Iva_Scorporata = entity.Iva_Scorporata,
                Iva_Annullato = entity.Iva_Annullato,
                Iva_Estero = entity.Iva_Estero,
                Iva_NaturaFE = entity.Iva_NaturaFE,
                Iva_NaturaSC = entity.Iva_NaturaSC
            };
        }

        private DbAliquoteIVA MapToEntity(AliquoteIVADTO dto)
        {
            if (dto == null) return null;
            return new DbAliquoteIVA
            {
                Iva_IDAuto = dto.Iva_IDAuto,
                Iva_Descrizione = dto.Iva_Descrizione,
                Iva_Aliquota = dto.Iva_Aliquota,
                Iva_Esenzione = dto.Iva_Esenzione,
                Iva_Scorporata = dto.Iva_Scorporata,
                Iva_Annullato = dto.Iva_Annullato,
                Iva_Estero = dto.Iva_Estero,
                Iva_NaturaFE = dto.Iva_NaturaFE,
                Iva_NaturaSC = dto.Iva_NaturaSC
            };
        }
    }
}