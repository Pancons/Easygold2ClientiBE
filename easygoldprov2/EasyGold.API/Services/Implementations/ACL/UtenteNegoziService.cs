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
    public class UtenteNegoziService : IUtenteNegoziService
    {
        private readonly IUtenteNegoziRepository _repository;

        public UtenteNegoziService(IUtenteNegoziRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<UtenteNegoziDTO>> GetAllAsync(UtenteNegoziListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<UtenteNegoziDTO>(items, total);
        }

          public async Task<UtenteNegoziDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<UtenteNegoziDTO> AddAsync(UtenteNegoziDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<UtenteNegoziDTO> UpdateAsync(UtenteNegoziDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Utn_IDAuto);
            if (entity == null) return null;
     
         
            entity.Utn_IDUtente = dto.Utn_IDUtente;
            entity.Utn_IDNegozio = dto.Utn_IDNegozio;
            entity.Utn_Default = dto.Utn_Default;
            entity.Utn_Annullato = dto.Utn_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

           //QUESTO
        private UtenteNegoziDTO MapToDto(DbUtenteNegozi entity)
        {
            return new UtenteNegoziDTO
            {
                Utn_IDAuto = entity.Utn_IDAuto,
                Utn_IDUtente = entity.Utn_IDUtente,
                Utn_IDNegozio = entity.Utn_IDNegozio,
                Utn_Default = entity.Utn_Default,
                Utn_Annullato = entity.Utn_Annullato
            };
        }

        private DbUtenteNegozi MapToEntity(UtenteNegoziDTO dto)
        {
            return new DbUtenteNegozi
            {
                Utn_IDAuto = dto.Utn_IDAuto,
                Utn_IDUtente = dto.Utn_IDUtente,
                Utn_IDNegozio = dto.Utn_IDNegozio,
                Utn_Default = dto.Utn_Default,
                Utn_Annullato = dto.Utn_Annullato
            };
        }
    }
}