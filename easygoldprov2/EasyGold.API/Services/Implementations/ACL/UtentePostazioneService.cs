using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class UtentePostazioneService : IUtentePostazioneService
    {
        private readonly IUtentePostazioneRepository _repository;

        public UtentePostazioneService(IUtentePostazioneRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<UtentePostazioneDTO>> GetAllAsync(UtentePostazioneListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<UtentePostazioneDTO>(items, total);
        }

      public async Task<UtentePostazioneDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<UtentePostazioneDTO> AddAsync(UtentePostazioneDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<UtentePostazioneDTO> UpdateAsync(UtentePostazioneDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Upo_IDAuto);
            if (entity == null) return null;
     
            entity.Upo_IdUtente_IDNegozio = dto.Upo_IdUtente_IDNegozio;
            entity.Upo_IDPostazione = dto.Upo_IDPostazione;
            entity.Upo_Annullato = dto.Upo_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

           //QUESTO
        private UtentePostazioneDTO MapToDto(DbUtentePostazione entity)
        {
            return new UtentePostazioneDTO
            {
                Upo_IDAuto = entity.Upo_IDAuto,
                Upo_IdUtente_IDNegozio = entity.Upo_IdUtente_IDNegozio,
                Upo_IDPostazione = entity.Upo_IDPostazione,
                Upo_Annullato = entity.Upo_Annullato

            };
        }

        private DbUtentePostazione MapToEntity(UtentePostazioneDTO dto)
        {
            return new DbUtentePostazione
            {
                Upo_IDAuto = dto.Upo_IDAuto,
                Upo_IdUtente_IDNegozio = dto.Upo_IdUtente_IDNegozio,
                Upo_IDPostazione = dto.Upo_IDPostazione,
                Upo_Annullato = dto.Upo_Annullato

            };
        }
    }
}
