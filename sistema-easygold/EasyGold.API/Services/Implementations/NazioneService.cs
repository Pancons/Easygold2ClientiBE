using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Models.Entities;
using AutoMapper;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class NazioneService : INazioneService
    {
        private readonly INazioneRepository _nazioneRepository;
        private readonly IMapper _mapper;

        public NazioneService(INazioneRepository nazioneRepository, IMapper mapper)
        {
            _nazioneRepository = nazioneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NazioniDTO>> GetAllAsync(NazioniListRequest request)
        {
            var moduli = await _nazioneRepository.GetAllAsync(request);
            return _mapper.Map<IEnumerable<NazioniDTO>>(moduli);
        }

        public async Task<NazioniDTO> GetByIdAsync(int id)
        {
            var modulo = await _nazioneRepository.GetByIdAsync(id);
            return _mapper.Map<NazioniDTO>(modulo);
        }
    }
}
