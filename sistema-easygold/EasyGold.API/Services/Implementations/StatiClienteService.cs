using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Models.Entities;
using AutoMapper;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Valute;
using EasyGold.API.Models.StatiCliente;
using EasyGold.API.Models;
using EasyGold.API.Models.Allegati;

namespace EasyGold.API.Services.Implementations
{
    public class StatiClienteService : IStatiClienteService
    {
        private readonly IStatoClientiRepository _statoClienteRepository;
        private readonly IMapper _mapper;

        public StatiClienteService(IStatoClientiRepository statoClienteRepository, IMapper mapper)
        {
            _statoClienteRepository = statoClienteRepository;
            _mapper = mapper;
        }

        public async Task<BaseListResponse<StatoClienteDTO>> GetAllAsync(StatoClienteListRequest request)
        {
            var statiCliente = await _statoClienteRepository.GetAllAsync(request);
            return new BaseListResponse<StatoClienteDTO>
            {
                results = _mapper.Map<IEnumerable<StatoClienteDTO>>(statiCliente).ToList(),  // ? Mappa automaticamente senza "N/A"
                total = statiCliente.Count()
            };
        }

        public async Task<StatoClienteDTO> GetByIdAsync(int id)
        {
            var statoCliente = await _statoClienteRepository.GetByIdAsync(id);
            return _mapper.Map<StatoClienteDTO>(statoCliente);
        }
    }
}
