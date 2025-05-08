using AutoMapper;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Allegati;
using EasyGold.API.Models.DTO.Ruoli;
using EasyGold.API.Models.Entities.Ruoli;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services;
using EasyGold.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyGold.API.Services.Implementations
{
    public class RuoloService :IRuoloService
    {
        private readonly IRuoloRepository _RuoloRepository;

        public RuoloService(IRuoloRepository RuoloRepository, IMapper mapper)
        {
            _RuoloRepository = RuoloRepository;
             _mapper = mapper;
        }

         private readonly IMapper _mapper;

        public async Task<BaseListResponse<RuoloDTO>> GetAllRolesAsync()
        {
            var ruoli = await _RuoloRepository.GetAllAsync();
            return new BaseListResponse<RuoloDTO>
            {
                results = _mapper.Map<IEnumerable<RuoloDTO>>(ruoli).ToList(),  // ✅ Mappa automaticamente senza "N/A"
                total = ruoli.Count()
            };
        }

        public async Task<RuoloDTO> GetRoleByIdAsync(int id)
        {
            var ruolo = await  _RuoloRepository.GetAllAsync();
            return _mapper.Map<RuoloDTO>(ruolo);
        }

        public async Task AddRoleAsync(RuoloDTO ruoloDTO)
        {
            var ruolo = _mapper.Map<DbRuolo>(ruoloDTO);
            await _RuoloRepository.AddAsync(ruolo);
        }

        public async Task UpdateRoleAsync(RuoloDTO ruoloDTO)
        {
            var ruolo = _mapper.Map<DbRuolo>(ruoloDTO);
            await _RuoloRepository.UpdateAsync(ruolo);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _RuoloRepository.DeleteAsync(id);
        }
    }
}
