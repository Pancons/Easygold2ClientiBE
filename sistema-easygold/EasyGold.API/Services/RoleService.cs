using AutoMapper;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Roles;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Services;
using EasyGold.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyGold.API.Services
{
    public class RoleService :IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
             _mapper = mapper;
        }

         private readonly IMapper _mapper;

        public async Task<IEnumerable<RuoloDTO>> GetAllRolesAsync()
        {
            var ruoli = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RuoloDTO>>(ruoli);
        }

        public async Task<RuoloDTO> GetRoleByIdAsync(int id)
        {
            var ruolo = await  _roleRepository.GetAllAsync();
            return _mapper.Map<RuoloDTO>(ruolo);
        }

        public async Task AddRoleAsync(RuoloDTO ruoloDTO)
        {
            var ruolo = _mapper.Map<DbRuolo>(ruoloDTO);
            await _roleRepository.AddAsync(ruolo);
        }

        public async Task UpdateRoleAsync(RuoloDTO ruoloDTO)
        {
            var ruolo = _mapper.Map<DbRuolo>(ruoloDTO);
            await _roleRepository.UpdateAsync(ruolo);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
    }
}
