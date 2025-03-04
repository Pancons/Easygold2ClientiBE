using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Clients;
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
            var (clienti, total) = await _clienteRepository.GetClientiAsync(
                request.Filters, request.Offset, request.Limit, request.Sort?.Field, request.Sort?.Order);

            return new ClienteListResult
            {
                Clienti = _mapper.Map<IEnumerable<ClienteDTO>>(clienti),
                Total = total
            };
        }

        public async Task<ClienteDettaglioDTO> CreateClienteAsync(ClienteDettaglioDTO clienteDto)
        {
            var cliente = new DbCliente
            {
                Utw_NomeConnessione = clienteDto.Dtc_RagioneSociale,
                Utw_DataAttivazione = clienteDto.Utw_DataAttivazione,
                Utw_DataDisattivazione = clienteDto.Utw_DataDisattivazione,
                Utw_NegoziAttivabili = clienteDto.Configurazione.Utw_NegoziAttivabili,
                Utw_NegoziVirtuali = clienteDto.Configurazione.Utw_NegoziVirtuali,
                Utw_UtentiAttivi = clienteDto.Configurazione.Utw_UtentiAttivi,
                Utw_Blocco = clienteDto.Utw_Bloccato
            };

            var datiCliente = new DbDatiCliente
            {
                Dtc_IDCliente = cliente.Utw_IDClienteAuto,
                Dtc_RagioneSociale = clienteDto.Dtc_RagioneSociale,
                Dtc_Gioielleria = clienteDto.Dtc_Gioielleria,
                Dtc_Indirizzo = clienteDto.Dtc_Indirizzo,
                Dtc_CAP = clienteDto.Dtc_CAP,
                Dtc_Localita = clienteDto.Dtc_Citta,
                Dtc_Provincia = clienteDto.Dtc_Provincia,
                Dtc_StatoRegione = clienteDto.Dtc_StatoRegione,
                Dtc_Nazione = clienteDto.Dtc_Nazione,
                Dtc_PartitaIVA = clienteDto.Dtc_PartitaIVA,
                Dtc_CodiceFiscale = clienteDto.Dtc_CodiceFiscale,
                Dtc_REA = clienteDto.Dtc_REA,
                Dtc_CapitaleSociale = clienteDto.Dtc_CapitaleSociale,
                Dtc_PEC = clienteDto.Dtc_PEC,
                Dtc_ReferenteCognome = clienteDto.Dtc_ReferenteCognome,
                Dtc_ReferenteNome = clienteDto.Dtc_ReferenteNome,
                Dtc_ReferenteTelefono = clienteDto.Dtc_ReferenteTelefono,
                Dtc_ReferenteCellulare = clienteDto.Dtc_ReferenteCellulare,
                Dtc_ReferenteEmail = clienteDto.Dtc_ReferenteEmail,
                Dtc_ReferenteWeb = clienteDto.Dtc_ReferenteWeb,
                Dtc_Ranking = clienteDto.Dtc_Ranking
            };

            await _clienteRepository.AddClienteAsync(cliente, datiCliente);
            return clienteDto;
        }

        public async Task<ClienteDettaglioDTO> UpdateClienteAsync(int id, ClienteDettaglioDTO clienteDto)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
                return null;

            cliente.Dtc_RagioneSociale = clienteDto.Dtc_RagioneSociale;
            cliente.Dtc_Gioielleria = clienteDto.Dtc_Gioielleria;
            cliente.Dtc_Indirizzo = clienteDto.Dtc_Indirizzo;
            cliente.Dtc_Citta = clienteDto.Dtc_Citta;
            cliente.Dtc_CAP = clienteDto.Dtc_CAP;
            cliente.Dtc_Provincia = clienteDto.Dtc_Provincia;
            cliente.Dtc_StatoRegione = clienteDto.Dtc_StatoRegione;
            cliente.Dtc_Nazione = clienteDto.Dtc_Nazione;
            cliente.Dtc_PartitaIVA = clienteDto.Dtc_PartitaIVA;
            cliente.Dtc_CodiceFiscale = clienteDto.Dtc_CodiceFiscale;
            cliente.Dtc_REA = clienteDto.Dtc_REA;
            cliente.Dtc_CapitaleSociale = clienteDto.Dtc_CapitaleSociale;
            cliente.Dtc_PEC = clienteDto.Dtc_PEC;
            cliente.Dtc_ReferenteCognome = clienteDto.Dtc_ReferenteCognome;
            cliente.Dtc_ReferenteNome = clienteDto.Dtc_ReferenteNome;
            cliente.Dtc_ReferenteTelefono = clienteDto.Dtc_ReferenteTelefono;
            cliente.Dtc_ReferenteCellulare = clienteDto.Dtc_ReferenteCellulare;
            cliente.Dtc_ReferenteEmail = clienteDto.Dtc_ReferenteEmail;
            cliente.Dtc_ReferenteWeb = clienteDto.Dtc_ReferenteWeb;
            cliente.Dtc_Ranking = clienteDto.Dtc_Ranking;

            await _clienteRepository.UpdateClienteAsync(cliente);
            return clienteDto;
        }

        public async Task<ClienteDettaglioDTO> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
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
