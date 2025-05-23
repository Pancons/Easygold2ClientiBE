using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using AutoMapper;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Allegati;
using EasyGold.API.Models.DTO.Moduli;
using EasyGold.API.Models.Entities.Moduli;
using EasyGold.API.Services.Interfaces.ConfigProgramma;
using EasyGold.API.Repositories.Interfaces.ConfigProgramma;

namespace EasyGold.API.Services.Implementations.ConfigProgramma
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

        public async Task<BaseListResponse<ModuloDTO>> GetAllAsync()
        {
            var moduli = await _moduloRepository.GetAllAsync();

            return new BaseListResponse<ModuloDTO>
            {
                results = _mapper.Map<IEnumerable<ModuloDTO>>(moduli).ToList(),  // ✅ Mappa automaticamente senza "N/A"
                total = moduli.Count()
            };
        }

        public async Task<ModuloDTO> GetByIdAsync(int id)
        {
            var modulo = await _moduloRepository.GetByIdAsync(id);
            return _mapper.Map<ModuloDTO>(modulo);
        }

        public async Task AddAsync(ModuloDTO moduloDto)
        {
            var modulo = _mapper.Map<DbModuloEasygold>(moduloDto);
            await _moduloRepository.AddAsync(modulo);
        }

        public async Task UpdateAsync(ModuloDTO moduloDto)
        {
            var modulo = _mapper.Map<DbModuloEasygold>(moduloDto);
            await _moduloRepository.UpdateAsync(modulo);
        }

        public async Task DeleteAsync(int id)
        {
            await _moduloRepository.DeleteAsync(id);
        }
    }
}
