using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.Web2.Models.Cliente.Entities;
using AutoMapper;
using EasyGold.Web2.Models.Comune.GEO;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Comune.Valute;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Services.Implementations.ConfigData
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
