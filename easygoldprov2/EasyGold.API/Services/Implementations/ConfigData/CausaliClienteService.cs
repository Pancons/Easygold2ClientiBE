using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CausaliClienteService : ICausaliClienteService
    {
        private readonly ICausaliClienteRepository _repository;

        public CausaliClienteService(ICausaliClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<CausaliClienteDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<CausaliClienteDTO>(list, list.Count);
        }

        public async Task<CausaliClienteDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CausaliClienteDTO> AddAsync(CausaliClienteDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Cal_IDAuto = entity.Cal_IDAuto;
            return dto;
        }

        public async Task<CausaliClienteDTO> UpdateAsync(CausaliClienteDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Cal_IDAuto);
            if (entity == null) return null;

            entity.Cal_Descrizione = dto.Cal_Descrizione;
            entity.Cal_IDDoveUso = dto.Cal_IDDoveUso;
            entity.Cal_IDProgressivo = dto.Cal_IDProgressivo;
            entity.Cal_IDtipoAnagrafica = dto.Cal_IDtipoAnagrafica;
            entity.Cal_IDtipoIVA = dto.Cal_IDtipoIVA;
            entity.Cal_Annulla = dto.Cal_Annulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private CausaliClienteDTO MapToDto(DbCausaliCliente entity)
        {
            if (entity == null) return null;
            return new CausaliClienteDTO
            {
                Cal_IDAuto = entity.Cal_IDAuto,
                Cal_Descrizione = entity.Cal_Descrizione,
                Cal_IDDoveUso = entity.Cal_IDDoveUso,
                Cal_IDProgressivo = entity.Cal_IDProgressivo,
                Cal_IDtipoAnagrafica = entity.Cal_IDtipoAnagrafica,
                Cal_IDtipoIVA = entity.Cal_IDtipoIVA,
                Cal_Annulla = entity.Cal_Annulla
            };
        }

        private DbCausaliCliente MapToEntity(CausaliClienteDTO dto)
        {
            if (dto == null) return null;
            return new DbCausaliCliente
            {
                Cal_IDAuto = dto.Cal_IDAuto,
                Cal_Descrizione = dto.Cal_Descrizione,
                Cal_IDDoveUso = dto.Cal_IDDoveUso,
                Cal_IDProgressivo = dto.Cal_IDProgressivo,
                Cal_IDtipoAnagrafica = dto.Cal_IDtipoAnagrafica,
                Cal_IDtipoIVA = dto.Cal_IDtipoIVA,
                Cal_Annulla = dto.Cal_Annulla
            };
        }
    }
}