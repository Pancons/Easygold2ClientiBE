using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Models.Entities;
using AutoMapper;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.DTO.Nazioni;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Utenti;
using EasyGold.API.Models.DTO.Valute;

namespace EasyGold.API.Services.Implementations
{
    public class ValutaService : IValutaService
    {
        private readonly IValutaRepository _valutaRepository;
        private readonly IMapper _mapper;

        public ValutaService(IValutaRepository valutaRepository, IMapper mapper)
        {
            _valutaRepository = valutaRepository;
            _mapper = mapper;
        }

        public async Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest request)
        {
            var valute = await _valutaRepository.GetAllAsync(request);
            return new BaseListResponse<ValuteDTO>
            {
                results = _mapper.Map<IEnumerable<ValuteDTO>>(valute).ToList(),  // ? Mappa automaticamente senza "N/A"
                total = valute.Count()
            };
        }

        public async Task<ValuteDTO> GetByIdAsync(int id)
        {
            var valuta = await _valutaRepository.GetByIdAsync(id);
            return _mapper.Map<ValuteDTO>(valuta);
        }
    }
}
