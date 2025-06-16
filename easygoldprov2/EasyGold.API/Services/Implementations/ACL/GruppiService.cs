<<<<<<< HEAD
using AutoMapper;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Gruppi;
using EasyGold.API.Models.Entities.Gruppi;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class GruppiService : IGruppiService
    {
        private readonly IGruppiRepository _gruppiRepository;
        private readonly IMapper _mapper;

        public GruppiService(IGruppiRepository gruppiRepository, IMapper mapper)
        {
            _gruppiRepository = gruppiRepository;
            _mapper = mapper;
        }



















=======
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
>>>>>>> e463d041ff2e631345a0fd6fa8e4ab20e4557f58

namespace EasyGold.API.Services.Implementations.ACL
{
    public class GruppiService : IGruppiService
    {
        private readonly IGruppiRepository _repository;

<<<<<<< HEAD



























        public async Task<BaseListResponse<GruppiDTO>> GetAllAsync(BaseListRequest request)
        {

            var gruppi = (await _gruppiRepository.GetAllAsync()).AsQueryable();

    // Sorting
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(GruppiDTO.Gru_NomeGruppo))
                    {



                        gruppi = sort.Order.ToLower() == "desc"
                            ? gruppi.OrderByDescending(e => e.Gru_NomeGruppo)
                            : gruppi.OrderBy(e => e.Gru_NomeGruppo);
                    }
                }
            }




            var total = gruppi.Count();
            var paged = gruppi.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = _mapper.Map<IEnumerable<GruppiDTO>>(paged).ToList();

            return new BaseListResponse<GruppiDTO>(dtos, total);
        }

        public async Task<GruppiDTO> GetGroupByIdAsync(int id)
        {
            var gruppo = await _gruppiRepository.GetByIdAsync(id);
            return _mapper.Map<GruppiDTO>(gruppo);
        }


        public async Task AddGroupAsync(GruppiDTO gruppiDTO)
        {
            var gruppo = _mapper.Map<DbGruppi>(gruppiDTO);
            await _gruppiRepository.AddAsync(gruppo);
        }























        public async Task<GruppiDTO> UpdateAsync(GruppiDTO dto)
        {
            var existingGroup = await _gruppiRepository.GetByIdAsync(dto.Gru_IDGruppo ?? 0);
            if (existingGroup != null)
            {
                _mapper.Map(dto, existingGroup);
                await _gruppiRepository.UpdateAsync(existingGroup);
                return _mapper.Map<GruppiDTO>(existingGroup);
            }
            return null;
        }

        public async Task DeleteGroupAsync(int id)
        {
            await _gruppiRepository.DeleteAsync(id);
=======
        public GruppiService(IGruppiRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<GruppiDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var list = entities.Select(MapToDto).ToList();
            return new BaseListResponse<GruppiDTO>(list, list.Count);
        }

        public async Task<GruppiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<GruppiDTO> AddAsync(GruppiDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            dto.Grp_IDAuto = entity.Grp_IDAuto;
            return dto;
        }

        public async Task<GruppiDTO> UpdateAsync(GruppiDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Grp_IDAuto);
            if (entity == null) return null;

            entity.Grp_NomeGruppo = dto.Grp_NomeGruppo;
            entity.Grp_DesGruppo = dto.Grp_DesGruppo;
            entity.Grp_SuperAdmin = dto.Grp_SuperAdmin;
            entity.Grp_Bloccato = dto.Grp_Bloccato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private GruppiDTO MapToDto(DbGruppi entity)
        {
            if (entity == null) return null;
            return new GruppiDTO
            {
                Grp_IDAuto = entity.Grp_IDAuto,
                Grp_NomeGruppo = entity.Grp_NomeGruppo,
                Grp_DesGruppo = entity.Grp_DesGruppo ?? string.Empty,
                Grp_SuperAdmin = entity.Grp_SuperAdmin ?? false,
                Grp_Bloccato = entity.Grp_Bloccato ?? false
            };
        }

        private DbGruppi MapToEntity(GruppiDTO dto)
        {
            if (dto == null) return null;
            return new DbGruppi
            {
                Grp_IDAuto = dto.Grp_IDAuto,
                Grp_NomeGruppo = dto.Grp_NomeGruppo,
                Grp_DesGruppo = dto.Grp_DesGruppo,
                Grp_SuperAdmin = dto.Grp_SuperAdmin,
                Grp_Bloccato = dto.Grp_Bloccato
            };
>>>>>>> e463d041ff2e631345a0fd6fa8e4ab20e4557f58
        }
    }
}
