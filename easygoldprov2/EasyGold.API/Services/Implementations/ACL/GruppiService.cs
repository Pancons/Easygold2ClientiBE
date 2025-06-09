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
        }
    }
}
