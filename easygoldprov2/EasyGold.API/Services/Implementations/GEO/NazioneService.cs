using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.Web2.Models.Cliente.Entities;
using AutoMapper;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Allegati;
using EasyGold.Web2.Models.Comune.GEO;
using EasyGold.API.Services.Interfaces.GEO;
using EasyGold.API.Repositories.Interfaces.GEO;

namespace EasyGold.API.Services.Implementations.GEO
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

        public async Task<BaseListResponse<NazioniDTO>> GetAllAsync(NazioniListRequest request)
        {
            var nazioni = await _nazioneRepository.GetAllAsync(request);
            return new BaseListResponse<NazioniDTO>
            {
                results = _mapper.Map<IEnumerable<NazioniDTO>>(nazioni).ToList(),  // ✅ Mappa automaticamente senza "N/A"
                total = nazioni.Count()
            };
        }

        public async Task<NazioniDTO> GetByIdAsync(int id)
        {
            var modulo = await _nazioneRepository.GetByIdAsync(id);
            return _mapper.Map<NazioniDTO>(modulo);
        }
    }
}
