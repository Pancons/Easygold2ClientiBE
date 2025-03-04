using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Allegati;
using AutoMapper;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class AllegatoService : IAllegatoService
    {
        private readonly IAllegatoRepository _allegatoRepository;
        private readonly IMapper _mapper;

        public AllegatoService(IAllegatoRepository allegatoRepository, IMapper mapper)
        {
            _allegatoRepository = allegatoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllegatoDTO>> GetAllAsync()
        {
            var allegati = await _allegatoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AllegatoDTO>>(allegati);
        }

        public async Task<AllegatoDTO> GetByIdAsync(int id)
        {
            var allegato = await _allegatoRepository.GetByIdAsync(id);
            return _mapper.Map<AllegatoDTO>(allegato);
        }

        public async Task AddAsync(AllegatoDTO allegatoDto)
        {
            var allegato = _mapper.Map<DbAllegato>(allegatoDto);
            await _allegatoRepository.AddAsync(allegato);
        }

        public async Task UpdateAsync(AllegatoDTO allegatoDto)
        {
            var allegato = _mapper.Map<DbAllegato>(allegatoDto);
            await _allegatoRepository.UpdateAsync(allegato);
        }

        public async Task DeleteAsync(int id)
        {
            await _allegatoRepository.DeleteAsync(id);
        }
    }


}