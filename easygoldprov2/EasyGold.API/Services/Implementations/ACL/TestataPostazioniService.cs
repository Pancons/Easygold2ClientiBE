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
    public class TestataPostazioniService : ITestataPostazioniService
    {
        private readonly ITestataPostazioniRepository _repository;

        public TestataPostazioniService(ITestataPostazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<TestataPostazioniDTO>> GetAllAsync(TestataPostazioniListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var items = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<TestataPostazioniDTO>(items, total);
        }

         public async Task<TestataPostazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<TestataPostazioniDTO> AddAsync(TestataPostazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TestataPostazioniDTO> UpdateAsync(TestataPostazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.tpo_IDAuto);
            if (entity == null) return null;
     
            entity.tpo_descizione = dto.tpo_descizione;
            entity.tpo_registratore = dto.tpo_registratore;
            entity.tpo_stampanti = dto.tpo_stampanti;
            entity.tpo_card = dto.tpo_card;
            entity.tpo_annullato = dto.tpo_annullato;


            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

           //QUESTO
        private TestataPostazioniDTO MapToDto(DbTestataPostazioni entity)
        {
            return new TestataPostazioniDTO
            {
                tpo_IDAuto = entity.tpo_IDAuto,
                tpo_descizione = entity.tpo_descizione,
                tpo_registratore = entity.tpo_registratore,
                tpo_stampanti = entity.tpo_stampanti,
                tpo_card = entity.tpo_card,
                tpo_annullato = entity.tpo_annullato
            };
        }

        private DbTestataPostazioni MapToEntity(TestataPostazioniDTO dto)
        {
            return new DbTestataPostazioni
            {
                tpo_IDAuto = dto.tpo_IDAuto,
                tpo_descizione = dto.tpo_descizione,
                tpo_registratore = dto.tpo_registratore,
                tpo_stampanti = dto.tpo_stampanti,
                tpo_card = dto.tpo_card,
                tpo_annullato = dto.tpo_annullato
                // Map any necessary properties or relationships
            };
        }
    }
}
