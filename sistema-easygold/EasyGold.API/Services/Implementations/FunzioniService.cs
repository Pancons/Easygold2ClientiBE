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

namespace EasyGold.API.Services.Implementations
{
    public class FunzioniService : IFunzioniService
    {
        private readonly IFunzioniRepository _repository;

        public FunzioniService(IFunzioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<FunzioniDTO>> GetAllAsync(FunzioniListRequest filter, string language)
        {
            var (entities, total) = await _repository.GetAllAsync(filter, language);
            var dtos = entities.Select(MapToDto).ToList();
            
            return new BaseListResponse<FunzioniDTO>(dtos, total);
        }

        public async Task<FunzioniDTO> GetByIdAsync(int id, string language)
        {
            var entity = await _repository.GetByIdAsync(id, language);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<FunzioniDTO> AddAsync(FunzioniDTO dto,string language)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity, language);
            return MapToDto(entity);
        }
       

        public async Task<FunzioniDTO> UpdateAsync(FunzioniDTO dto, string language)
        {
            var entity = await _repository.GetByIdAsync(dto.Abl_IDAuto, "en"); // Default to "en" if necessary here
            if (entity == null) return null;

            entity.Abl_DescFunzione = dto.Abl_DescFunzione;
            entity.Abl_DescFunzioneEstesa = dto.Abl_DescFunzioneEstesa;
            entity.Abl_Annullato = dto.Abl_Annullato;

            await _repository.UpdateAsync(entity,language);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private FunzioniDTO MapToDto(DbFunzioni entity)
        {
            return new FunzioniDTO
            {
                Abl_IDAuto = entity.Abl_IDAuto,
                Abl_IDPadre = entity.Abl_IDPadre,
                Abl_DescFunzione = entity.Abl_DescFunzione,
                Abl_DescFunzioneEstesa = entity.Abl_DescFunzioneEstesa,
                Abl_Annullato = entity.Abl_Annullato,
                /*PermessiGruppo = entity.PermessiGruppo.Select(pg => new PermessiGruppoDTO
                {
                    // Map properties from DbPermessiGruppo to PermessiGruppoDTO
                }).ToList()*/
            };
        }

        private DbFunzioni MapToEntity(FunzioniDTO dto)
        {
            return new DbFunzioni
            {
                Abl_IDAuto = dto.Abl_IDAuto,
                Abl_IDPadre = dto.Abl_IDPadre,
                Abl_DescFunzione = dto.Abl_DescFunzione,
                Abl_DescFunzioneEstesa = dto.Abl_DescFunzioneEstesa,
                Abl_Annullato = dto.Abl_Annullato,
                // Map any necessary properties or relationships
            };
        }
    }
}