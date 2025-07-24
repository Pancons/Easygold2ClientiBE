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
    public class FiscalePostazioniService : IFiscalePostazioniService
    {
        private readonly IFiscalePostazioniRepository _repository;

        public FiscalePostazioniService(IFiscalePostazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<FiscalePostazioniDTO>> GetAllAsync(FiscalePostazioniListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var list = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<FiscalePostazioniDTO>(list, total);
        }

        public async Task<FiscalePostazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

         public async Task<FiscalePostazioniDTO> AddAsync(FiscalePostazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<FiscalePostazioniDTO> UpdateAsync(FiscalePostazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Fpo_IDAuto);
            if (entity == null) return null;
            
            entity.Fpo_IDPostazione = dto.Fpo_IDPostazione;
            entity.Fpo_IDRegFiscale = dto.Fpo_IDRegFiscale;
            entity.Fpo_IPPath = dto.Fpo_IPPath;
            entity.Fpo_Attivo = dto.Fpo_Attivo;
            entity.Fpo_Annullato = dto.Fpo_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }


        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        
        //QUESTO
        private FiscalePostazioniDTO MapToDto(DbFiscalePostazioni entity)
        {
            return new FiscalePostazioniDTO
            {
                Fpo_IDAuto = entity.Fpo_IDAuto,
                Fpo_IDPostazione = entity.Fpo_IDPostazione,
                Fpo_IDRegFiscale = entity.Fpo_IDRegFiscale,
                Fpo_IPPath = entity.Fpo_IPPath,
                Fpo_Attivo = entity.Fpo_Attivo,
                Fpo_Annullato = entity.Fpo_Annullato
            };
        }

        private DbFiscalePostazioni MapToEntity(FiscalePostazioniDTO dto)
        {
            return new DbFiscalePostazioni
            {
                Fpo_IDAuto = dto.Fpo_IDAuto,
                Fpo_IDPostazione = dto.Fpo_IDPostazione,
                Fpo_IDRegFiscale = dto.Fpo_IDRegFiscale,
                Fpo_IPPath = dto.Fpo_IPPath,
                Fpo_Attivo = dto.Fpo_Attivo,
                Fpo_Annullato = dto.Fpo_Annullato
            };
        }


    }
}