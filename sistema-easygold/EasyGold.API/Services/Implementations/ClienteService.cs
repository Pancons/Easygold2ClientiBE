using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Moduli;
using AutoMapper;
using EasyGold.API.Models;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteListResult> GetClientiListAsync(ClienteListRequest request)
        {
            // Chiamata diretta con l'intero oggetto request (compatibile con ordinamento multiplo)
            var (clientiData, total) = await _clienteRepository.GetClientiAsync(request);

            return new ClienteListResult
            {
                Clienti = _mapper.Map<IEnumerable<ClienteDettaglioDTO>>(clientiData),  // ✅ Mappa automaticamente senza "N/A"
                Total = total
            };
        }

        public async Task<ClienteDettaglioDTO> CreateClienteAsync(ClienteDettaglioDTO clienteDto)
        {
            // Mappa il DTO in oggetti Db
            var cliente = _mapper.Map<DbCliente>(clienteDto);
            var datiCliente = _mapper.Map<DbDatiCliente>(clienteDto);
            var moduli = _mapper.Map<List<ModuloIntermedio>>(clienteDto.Moduli);
            var allegati = _mapper.Map<List<DbAllegato>>(clienteDto.Allegati);
            var negozi = _mapper.Map<List<DbNegozi>>(clienteDto.Negozi);

            datiCliente.Dtc_IDValuta = clienteDto.Configurazione?.Utw_IDValuta;
            datiCliente.Dtc_NumeroContratto = clienteDto.Configurazione?.Utw_NumeroContratto;

            Console.WriteLine($"Moduli: {moduli.Count}, Allegati: {allegati.Count}, Negozi: {negozi.Count}");
            // Salva nel database tramite repository
            await _clienteRepository.AddClienteAsync(cliente, datiCliente, moduli, allegati, negozi);

            return await GetByIdAsync(cliente.Utw_IDClienteAuto);
        }

        public async Task<ClienteDettaglioDTO> UpdateClienteAsync(int id, ClienteDettaglioDTO clienteDto)
        {
            var clienteData = await _clienteRepository.GetClienteByIdAsync(id);

            // Se il cliente non esiste, ritorna null
            if (clienteData.Cliente == null)
                return null;

            // Mappa solo le proprietà aggiornabili
            _mapper.Map(clienteDto, clienteData.Cliente);
            _mapper.Map(clienteDto, clienteData.DatiCliente);
            var moduli = _mapper.Map<List<ModuloIntermedio>>(clienteDto.Moduli);
            var allegati = _mapper.Map<List<DbAllegato>>(clienteDto.Allegati);
            var negozi = _mapper.Map<List<DbNegozi>>(clienteDto.Negozi);
            var modulicliente = _mapper.Map<List<DbModuloCliente>>(clienteDto.Moduli);

            // Aggiorna i dati tramite repository
            await _clienteRepository.UpdateClienteAsync(clienteData.Cliente, clienteData.DatiCliente, moduli, allegati, negozi);

            return clienteDto;
        }

        public async Task<ClienteDettaglioDTO> GetByIdAsync(int id)
        {
            // Recupera i dati dalla repository come tupla
            var clienteData = await _clienteRepository.GetClienteByIdAsync(id);

            // Controllo su null: Se il cliente non esiste, ritorna null
            if (clienteData.Cliente == null)
                return null;

            return _mapper.Map<ClienteDettaglioDTO>(clienteData);
        }

        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
       

        /*
public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
{
    var clienti = await _clienteRepository.GetAllAsync();
    return _mapper.Map<IEnumerable<ClienteDTO>>(clienti);
}

public async Task<ClienteDettaglioDTO> GetByIdAsync(int id)
{
    var cliente = await _clienteRepository.GetByIdAsync(id);
    return _mapper.Map<ClienteDettaglioDTO>(cliente);
}

public async Task AddAsync(ClienteDettaglioDTO clienteDettaglioDto)
{
    var cliente = _mapper.Map<DbCliente>(clienteDettaglioDto);
    await _clienteRepository.AddAsync(cliente);
}

public async Task UpdateAsync(ClienteDettaglioDTO clienteDettaglioDto)
{
    var cliente = _mapper.Map<DbCliente>(clienteDettaglioDto);
    await _clienteRepository.UpdateAsync(cliente);
}

public async Task DeleteAsync(int id)
{
    await _clienteRepository.DeleteAsync(id);
}
*/


    }
}
