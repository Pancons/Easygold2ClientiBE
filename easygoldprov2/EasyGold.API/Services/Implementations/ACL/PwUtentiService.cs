using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class PwUtentiService : IPwUtentiService
    {
        private readonly IPwUtentiRepository _repository;

        public PwUtentiService(IPwUtentiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<PwUtentiDTO>> GetAllAsync(PwUtentiListRequest filter)
        {
            var (entities, total) = await _repository.GetAllAsync(filter);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<PwUtentiDTO>(dtos, total);
        }

        public async Task<PwUtentiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<PwUtentiDTO> AddAsync(PwUtentiDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<PwUtentiDTO> UpdateAsync(PwUtentiDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Utp_IDAuto);
            if (entity == null) return null;

            entity.Utp_IDUtente = dto.Utp_IDUtente;
            entity.Utp_TipoPw = dto.Utp_TipoPw;
            entity.Utp_PwUtente = dto.Utp_PwUtente;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private PwUtentiDTO MapToDto(DbPwUtenti entity)
        {
            return new PwUtentiDTO
            {
                Utp_IDAuto = entity.Utp_IDAuto,
                Utp_IDUtente = entity.Utp_IDUtente,
                Utp_TipoPw = entity.Utp_TipoPw,
                Utp_PwUtente = entity.Utp_PwUtente
            };
        }

        private DbPwUtenti MapToEntity(PwUtentiDTO dto)
        {
            return new DbPwUtenti
            {
                Utp_IDAuto = dto.Utp_IDAuto,
                Utp_IDUtente = dto.Utp_IDUtente,
                Utp_TipoPw = dto.Utp_TipoPw,
                Utp_PwUtente = dto.Utp_PwUtente
            };
        }
    }
}