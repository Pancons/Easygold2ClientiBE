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
    public class StampePostazioniService : IStampePostazioniService
    {
        private readonly IStampePostazioniRepository _repository;

        public StampePostazioniService(IStampePostazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<StampePostazioniDTO>> GetAllAsync(StampePostazioniListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<StampePostazioniDTO>(items, total);
        }

        public async Task<StampePostazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<StampePostazioniDTO> AddAsync(StampePostazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<StampePostazioniDTO> UpdateAsync(StampePostazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Tpo_IDAuto);
            if (entity == null) return null;
     
            entity.Tpo_IDPostazione = dto.Tpo_IDPostazione;
            entity.Tpo_IDStampa = dto.Tpo_IDStampa;
            entity.Tpo_IPDevice = dto.Tpo_IPDevice;
            entity.Tpo_Device = dto.Tpo_Device;
            entity.Tpo_Diretta = dto.Tpo_Diretta;
            entity.Tpo_Annullato = dto.Tpo_Annullato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

           //QUESTO
        private StampePostazioniDTO MapToDto(DbStampePostazioni entity)
        {
            return new StampePostazioniDTO
            {
                Tpo_IDAuto = entity.Tpo_IDAuto,
                Tpo_IDPostazione = entity.Tpo_IDPostazione,
                Tpo_IDStampa = entity.Tpo_IDStampa,
                Tpo_IPDevice = entity.Tpo_IPDevice,
                Tpo_Device = entity.Tpo_Device,
                Tpo_Diretta = entity.Tpo_Diretta,
                Tpo_Annullato = entity.Tpo_Annullato
            };
        }

        private DbStampePostazioni MapToEntity(StampePostazioniDTO dto)
        {
            return new DbStampePostazioni
            {
                Tpo_IDAuto = dto.Tpo_IDAuto,
                Tpo_IDPostazione = dto.Tpo_IDPostazione,
                Tpo_IDStampa = dto.Tpo_IDStampa,
                Tpo_IPDevice = dto.Tpo_IPDevice,
                Tpo_Device = dto.Tpo_Device,
                Tpo_Diretta = dto.Tpo_Diretta,
                Tpo_Annullato = dto.Tpo_Annullato
            };
        }



    }
}
