using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Models.Entities;
using AutoMapper;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Clients;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public ModuloService(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModuloDTO>> GetAllAsync()
        {
            var moduli = await _moduloRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ModuloDTO>>(moduli);
        }

        public async Task<ModuloDTO> GetByIdAsync(int id)
        {
            var modulo = await _moduloRepository.GetByIdAsync(id);
            return _mapper.Map<ModuloDTO>(modulo);
        }

        public async Task AddAsync(ModuloDTO moduloDto)
        {
            var modulo = _mapper.Map<DbModuloCliente>(moduloDto);
            await _moduloRepository.AddAsync(modulo);
        }

        public async Task UpdateAsync(ModuloDTO moduloDto)
        {
            var modulo = _mapper.Map<DbModuloCliente>(moduloDto);
            await _moduloRepository.UpdateAsync(modulo);
        }

        public async Task DeleteAsync(int id)
        {
            await _moduloRepository.DeleteAsync(id);
        }
    }
}
