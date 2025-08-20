using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.API.Services.Interfaces.Anagrafiche;

namespace EasyGold.API.Services.Implementations.Anagrafiche
{
    public class NazioneFiscoService : INazioneFiscoService
    {
        private readonly INazioneFiscoRepository _repository;

        public NazioneFiscoService(INazioneFiscoRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<NazioneFiscoDTO>> GetAllAsync(NazioneFiscoListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<NazioneFiscoDTO>(list, total);
        }

        public async Task<NazioneFiscoDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<NazioneFiscoDTO> AddAsync(NazioneFiscoDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<NazioneFiscoDTO> UpdateAsync(NazioneFiscoDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Nfs_IDAuto);
            if (entity == null) return null;

            entity.Nfs_IDNazione = dto.Nfs_IDNazione;
            entity.Nfs_Descrizione = dto.Nfs_Descrizione;
            entity.Nfs_TipoCampo = dto.Nfs_TipoCampo;
            entity.Nfs_Obbligatorio = dto.Nfs_Obbligatorio;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private NazioneFiscoDTO MapToDto(DbNazioneFisco entity)
        {
            return new NazioneFiscoDTO
            {
                Nfs_IDAuto = entity.Nfs_IDAuto,
                Nfs_IDNazione = entity.Nfs_IDNazione,
                Nfs_Descrizione = entity.Nfs_Descrizione,
                Nfs_TipoCampo = entity.Nfs_TipoCampo,
                Nfs_Obbligatorio = entity.Nfs_Obbligatorio
            };
        }

        private DbNazioneFisco MapToEntity(NazioneFiscoDTO dto)
        {
            return new DbNazioneFisco
            {
                Nfs_IDAuto = dto.Nfs_IDAuto,
                Nfs_IDNazione = dto.Nfs_IDNazione,
                Nfs_Descrizione = dto.Nfs_Descrizione,
                Nfs_TipoCampo = dto.Nfs_TipoCampo,
                Nfs_Obbligatorio = dto.Nfs_Obbligatorio
            };
        }
    }
}