using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Clients;
using EasyGold.API.Models.Configurazioni;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyGold.API.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCliente> Clienti, int Total)> GetClientiAsync(
        ClienteFilter filters, int offset, int limit, string sortField, string sortOrder)
        {
            var query = from cliente in _context.Clienti
                        join datiCliente in _context.DatiClienti
                        on cliente.Utw_IDClienteAuto equals datiCliente.Dtc_IDCliente
                        where (string.IsNullOrEmpty(filters.DtcRagioneSociale) || datiCliente.Dtc_RagioneSociale.Contains(filters.DtcRagioneSociale))
                           && (string.IsNullOrEmpty(filters.DtcGioielleria) || datiCliente.Dtc_Gioielleria.Contains(filters.DtcGioielleria))
                           && (!filters.NonAttivi.HasValue || (filters.NonAttivi.Value && cliente.Utw_DataDisattivazione != null))
                           && (!filters.Scaduti.HasValue || (filters.Scaduti.Value && cliente.Utw_DataAttivazione < DateTime.UtcNow.AddYears(-1)))
                        select cliente;

            int total = await query.CountAsync();

            if (!string.IsNullOrEmpty(sortField))
            {
                query = sortOrder.ToLower() == "asc"
                    ? query.OrderBy(c => EF.Property<object>(c, sortField))
                    : query.OrderByDescending(c => EF.Property<object>(c, sortField));
            }

            var clienti = await query.Skip(offset).Take(limit).ToListAsync();
            return (clienti, total);
        }

        public async Task AddClienteAsync(DbCliente cliente, DbDatiCliente datiCliente)
        {
            await _context.Clienti.AddAsync(cliente);
            await _context.DatiClienti.AddAsync(datiCliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(ClienteDettaglioDTO clienteDto)
        {
            var cliente = await _context.Clienti.FindAsync(clienteDto.Utw_IDClienteAuto);
            if (cliente == null) return;

            cliente.Utw_NomeConnessione = clienteDto.Dtc_RagioneSociale;
            cliente.Utw_DataAttivazione = clienteDto.Utw_DataAttivazione;
            cliente.Utw_DataDisattivazione = clienteDto.Utw_DataDisattivazione;
            cliente.Utw_NegoziAttivabili = clienteDto.Configurazione.Utw_NegoziAttivabili;
            cliente.Utw_NegoziVirtuali = clienteDto.Configurazione.Utw_NegoziVirtuali;
            cliente.Utw_UtentiAttivi = clienteDto.Configurazione.Utw_UtentiAttivi;
            cliente.Utw_Blocco = clienteDto.Utw_Bloccato;

            _context.Clienti.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteDettaglioDTO> GetClienteByIdAsync(int id)
        {
            // Recupero i dati principali del Cliente con Join sui dati anagrafici
            var cliente = await (from c in _context.Clienti
                                 join d in _context.DatiClienti on c.Utw_IDClienteAuto equals d.Dtc_IDCliente
                                 where c.Utw_IDClienteAuto == id
                                 select new ClienteDettaglioDTO
                                 {
                                     Utw_IDClienteAuto = c.Utw_IDClienteAuto,
                                     Dtc_RagioneSociale = d.Dtc_RagioneSociale,
                                     Dtc_Gioielleria = d.Dtc_Gioielleria,
                                     Dtc_Indirizzo = d.Dtc_Indirizzo,
                                     Dtc_Citta = d.Dtc_Localita,
                                     Dtc_CAP = d.Dtc_CAP,
                                     Dtc_Provincia = d.Dtc_Provincia,
                                     Dtc_StatoRegione = d.Dtc_StatoRegione,
                                     Dtc_Nazione = d.Dtc_Nazione,
                                     Dtc_PartitaIVA = d.Dtc_PartitaIVA,
                                     Dtc_CodiceFiscale = d.Dtc_CodiceFiscale,
                                     Dtc_REA = d.Dtc_REA,
                                     Dtc_CapitaleSociale = d.Dtc_CapitaleSociale,
                                     Dtc_PEC = d.Dtc_PEC,
                                     Dtc_ReferenteCognome = d.Dtc_ReferenteCognome,
                                     Dtc_ReferenteNome = d.Dtc_ReferenteNome,
                                     Dtc_ReferenteTelefono = d.Dtc_ReferenteTelefono,
                                     Dtc_ReferenteCellulare = d.Dtc_ReferenteCellulare,
                                     Dtc_ReferenteEmail = d.Dtc_ReferenteEmail,
                                     Dtc_ReferenteWeb = d.Dtc_ReferenteWeb,
                                     Dtc_Ranking = d.Dtc_Ranking,
                                     Utw_DataAttivazione = c.Utw_DataAttivazione,
                                     Utw_DataDisattivazione = c.Utw_DataDisattivazione,
                                     Dtc_Stato = d.Dtc_StatoRegione,
                                     Utw_Attivo = c.Utw_DataDisattivazione == null,
                                     Utw_Bloccato = c.Utw_Blocco,

                                     // Configurazione cliente
                                     Configurazione = new ConfigurazioneDTO
                                     {
                                         Utw_NegoziAttivabili = c.Utw_NegoziAttivabili,
                                         Utw_NegoziVirtuali = c.Utw_NegoziVirtuali,
                                         Utw_UtentiAttivi = c.Utw_UtentiAttivi,
                                         Utw_DataAttivazione = c.Utw_DataAttivazione,
                                         Utw_DataDisattivazione = c.Utw_DataDisattivazione,
                                         Utw_Blocco = c.Utw_Blocco
                                     }
                                 }).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return null;
            }

            // Recupero separato dei Moduli associati al Cliente
            cliente.Moduli = await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == id)
                .Join(_context.ModuloEasygold,
                      mc => mc.Mdc_IDModulo,
                      me => me.Mde_IDAuto,
                      (mc, me) => new ModuloDTO
                      {
                          Mdc_IDModulo = me.Mde_IDAuto,
                          Mde_Descrizione = me.Mde_Descrizione,
                          Mde_DescrizioneEstesa = me.Mde_DescrizioneEstesa,
                          Mdc_DataAttivazione = mc.Mdc_DataAttivazione,
                          Mdc_DataDisattivazione = mc.Mdc_DataDisattivazione,
                          Mdc_BloccoModulo = mc.Mdc_BloccoModulo,
                          Mdc_DataOraBlocco = mc.Mdc_DataOraBlocco,
                          Mdc_Nota = mc.Mdc_Nota
                      }).ToListAsync();

            // Recupero separato degli Allegati associati al Cliente
            cliente.Allegati = await _context.Allegati
                .Where(a => a.All_EntitaRiferimento == "Cliente" && a.All_RecordId == id)
                .Select(a => new AllegatoDTO
                {
                    All_IDAllegato = a.All_IDAllegato,
                    All_NomeFile = a.All_NomeFile,
                    All_Estensione = a.All_Estensione,
                    All_Dimensione = a.All_Dimensione,
                    All_EntitaRiferimento = a.All_EntitaRiferimento,
                    All_RecordId = a.All_RecordId,
                    All_Note = a.All_Note,
                    All_ImgUrl = a.All_ImgUrl
                }).ToListAsync();

            // Recupero separato dei Negozi associati al Cliente
            cliente.Negozi = await _context.Negozi
                .Where(n => n.Neg_id == id)
                .Select(n => new NegozioDTO
                {
                    Id = n.Neg_id,
                    Neg_RagioneSociale = n.Neg_RagioneSociale,
                    Neg_NomeNegozio = n.Neg_NomeNegozio,
                    Neg_DataAttivazione = n.Neg_DataAttivazione,
                    Neg_DataDisattivazione = n.Neg_DataDisattivazione,
                    Neg_Bloccato = n.Neg_Bloccato,
                    Neg_Note = n.Neg_Note
                }).ToListAsync();

            return cliente;
        }
        /*
               public async Task<IEnumerable<DbCliente>> GetAllAsync()
               {
                   return await _context.Clienti.ToListAsync();
               }

               public async Task<DbCliente> GetByIdAsync(int id)
               {
                   return await _context.Clienti.FindAsync(id);
               }

               public async Task AddAsync(DbCliente cliente)
               {
                   await _context.Clienti.AddAsync(cliente);
                   await _context.SaveChangesAsync();
               }

               public async Task UpdateAsync(DbCliente cliente)
               {
                   _context.Clienti.Update(cliente);
                   await _context.SaveChangesAsync();
               }

               public async Task DeleteAsync(int id)
               {
                   var cliente = await GetByIdAsync(id);
                   if (cliente != null)
                   {
                       _context.Clienti.Remove(cliente);
                       await _context.SaveChangesAsync();
                   }
               }
               */

    }
}