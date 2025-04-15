using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Models.Configurazioni;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Moduli;
using System.Security.Principal;


namespace EasyGold.API.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IAllegatoRepository _allegatoRepository;
        private readonly IModuloClienteRepository _moduloClienteRepository;
        private readonly IModuloRepository _moduloRepository;
        private readonly INegozioRepository _negozioRepository;

        public ClienteRepository(ApplicationDbContext context, IAllegatoRepository allegatoRepository, IModuloClienteRepository moduloClienteRepository, IModuloRepository moduloRepository, INegozioRepository negozioRepository)
        {
            _context = context;
            _allegatoRepository = allegatoRepository;
            _moduloClienteRepository = moduloClienteRepository;
            _moduloRepository = moduloRepository;
            _negozioRepository = negozioRepository;
        }

        public async Task<(IEnumerable<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<Tuple<DbModuloEasygold, DbModuloCliente>>? Moduli, List<DbAllegato>? Allegati, List<DbNegozi>? Negozi, DbNazioni? Nazione, DbValute? Valuta, DbStatoCliente? StatoCliente)> Clienti, int Total)>
        GetClientiAsync(ClienteListRequest request)
        {
            var query = from cliente in _context.Clienti
                        join datiCliente in _context.DatiClienti
                            on cliente.Utw_IDClienteAuto equals datiCliente.Dtc_IDCliente into clientiGroup
                        from datiCliente in clientiGroup.DefaultIfEmpty()
                        where (request.Filters == null || string.IsNullOrEmpty(request.Filters.Dtc_RagioneSociale) || datiCliente.Dtc_RagioneSociale.Contains(request.Filters.Dtc_RagioneSociale))
                        && (request.Filters == null || string.IsNullOrEmpty(request.Filters.Dtc_Gioielleria) || datiCliente.Dtc_Gioielleria.Contains(request.Filters.Dtc_Gioielleria))
                        && (request.Filters == null || !request.Filters.NonAttivi.HasValue || (request.Filters.NonAttivi.Value && cliente.Utw_DataDisattivazione != null))
                        && (request.Filters == null || !request.Filters.Scaduti.HasValue || (request.Filters.Scaduti.Value && cliente.Utw_DataAttivazione < DateTime.UtcNow.AddYears(-1)))
                        select new ClienteRecord
                        {
                            Cliente = cliente,
                            DatiCliente = datiCliente
                        };

            int total = await query.CountAsync();

            // ✅ Ordinamento multiplo tip-safe
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<ClienteRecord>? orderedQuery = null;

                foreach (var sort in request.Sort)
                {
                    bool isClienteField = typeof(DbCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    bool isDatiClienteField = typeof(DbDatiCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;

                    if (isClienteField)
                    {
                        sort.Field = typeof(DbCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;
                        orderedQuery = orderedQuery == null
                            ? (sort.Order.ToLower() == "asc"
                                ? query.OrderBy(x => EF.Property<object>(x.Cliente, sort.Field))
                                : query.OrderByDescending(x => EF.Property<object>(x.Cliente, sort.Field)))
                            : (sort.Order.ToLower() == "asc"
                                ? orderedQuery.ThenBy(x => EF.Property<object>(x.Cliente, sort.Field))
                                : orderedQuery.ThenByDescending(x => EF.Property<object>(x.Cliente, sort.Field)));
                    }
                    else if (isDatiClienteField)
                    {
                        sort.Field = typeof(DbDatiCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;
                        orderedQuery = orderedQuery == null
                            ? (sort.Order.ToLower() == "asc"
                                ? query.OrderBy(x => EF.Property<object>(x.DatiCliente, sort.Field))
                                : query.OrderByDescending(x => EF.Property<object>(x.DatiCliente, sort.Field)))
                            : (sort.Order.ToLower() == "asc"
                                ? orderedQuery.ThenBy(x => EF.Property<object>(x.DatiCliente, sort.Field))
                                : orderedQuery.ThenByDescending(x => EF.Property<object>(x.DatiCliente, sort.Field)));
                    }
                }

                if (orderedQuery != null)
                    query = orderedQuery;
            }

            // ✅ Paginazione
            query = query.Skip(request.Offset).Take(request.Limit);

            // ✅ Esecuzione e mappatura
            var list = await query.ToListAsync();
            var result = list.Select(x => (x.Cliente, x.DatiCliente, _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == x.Cliente.Utw_IDClienteAuto)
                .Join(_context.ModuloEasygold,
                    mc => mc.Mdc_IDModulo,
                    me => me.Mde_IDAuto,
                    (mc, me) => new Tuple<DbModuloEasygold, DbModuloCliente>(me, mc))
                .ToList(),
                new List<DbAllegato>(),
                new List<DbNegozi>(),
                _context.Nazioni
                .Where(n => n.Naz_id == x.DatiCliente.Dtc_Nazione)
                .FirstOrDefaultAsync().Result,
                _context.Valute
                .Where(v => v.Val_id == x.DatiCliente.Dtc_IDValuta)
                .FirstOrDefaultAsync().Result,
                _context.StatiCliente
                .Where(sc => sc.Stc_id == x.Cliente.Utw_IdStatoCliente)
                .FirstOrDefaultAsync().Result)).ToList();

            return (result, total);
        }

        public async Task AddClienteAsync(
            DbCliente cliente,
            DbDatiCliente datiCliente,
            List<ModuloIntermedio> moduli,
            List<DbAllegato> allegati,
            List<DbNegozi> negozi)
        {
            // Aggiunta del cliente
            await _context.Clienti.AddAsync(cliente);
            await _context.SaveChangesAsync(); // Generazione dell'ID cliente

            // Assegnazione ID Cliente ai negozi
            negozi.ForEach(n => n.Neg_IDCliente = cliente.Utw_IDClienteAuto);

            // Aggiunta dei dati cliente
            await _context.DatiClienti.AddAsync(datiCliente);

            // **Gestione Allegati tramite Repository**
            foreach (var allegato in allegati)
            {
                allegato.All_RecordId = cliente.Utw_IDClienteAuto;
                await _allegatoRepository.AddAsync(allegato);
            }

            // **Gestione Negozi tramite Repository**
            foreach (var negozio in negozi)
            {
                var negozioEsistente = await _negozioRepository.GetByIdAsync(negozio.Neg_id);
                if (negozioEsistente == null)
                {
                    negozio.Neg_IDCliente = cliente.Utw_IDClienteAuto;
                    await _negozioRepository.AddAsync(negozio);
                }
            }

            // **Gestione Moduli: Creazione e Associazione**
            foreach (var modulo in moduli)
            {
                var moduloEsistente = await _moduloRepository.GetByIdAsync(modulo.Mde_IDAuto);
                if (moduloEsistente == null)
                {
                    var moduloEasygold = new DbModuloEasygold
                    {
                        Mde_Descrizione = modulo.Mde_Descrizione,
                        Mde_DescrizioneEstesa = modulo.Mde_DescrizioneEstesa
                    };
                    await _moduloRepository.AddAsync(moduloEasygold);
                    moduloEsistente = moduloEasygold; // Aggiorna il riferimento
                }

                var moduloCliente = new DbModuloCliente
                {
                    Mdc_IDCliente = cliente.Utw_IDClienteAuto,
                    Mdc_IDModulo = moduloEsistente.Mde_IDAuto,
                    Mdc_DataAttivazione = modulo.Mdc_DataAttivazione,
                    Mdc_DataDisattivazione = modulo.Mdc_DataDisattivazione,
                    Mdc_BloccoModulo = modulo.Mdc_BloccoModulo,
                    Mdc_DataOraBlocco = modulo.Mdc_DataOraBlocco,
                    Mdc_Nota = modulo.Mdc_Nota
                };
                await _moduloClienteRepository.AddAsync(moduloCliente);
            }

            // Salvataggio finale
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(
            DbCliente cliente,
            DbDatiCliente datiCliente,
            List<(DbModuloEasygold, DbModuloCliente)> moduli,
            List<DbAllegato> allegati,
            List<DbNegozi> negozi)
        {
            var clienteEsistente = await _context.Clienti.FindAsync(cliente.Utw_IDClienteAuto);
            if (clienteEsistente == null)
                throw new KeyNotFoundException("Cliente non trovato.");

            // **Aggiornamento Cliente**
            _context.Entry(clienteEsistente).CurrentValues.SetValues(cliente);

            // **Aggiornamento Dati Cliente**
            var datiClienteEsistenti = await _context.DatiClienti
                .FirstOrDefaultAsync(d => d.Dtc_IDCliente == cliente.Utw_IDClienteAuto);

            if (datiClienteEsistenti != null)
                _context.Entry(datiClienteEsistenti).CurrentValues.SetValues(datiCliente);
            else
                await _context.DatiClienti.AddAsync(datiCliente);

            // **Gestione Allegati tramite Repository**
            await _allegatoRepository.UpdateAllAsync(cliente.Utw_IDClienteAuto, "Cliente", allegati);

            // **Gestione Negozi tramite Repository**
            foreach (var negozio in negozi)
            {
                var negozioEsistente = await _negozioRepository.GetByIdAsync(negozio.Neg_id);

                if (negozioEsistente == null)
                {
                    negozio.Neg_IDCliente = cliente.Utw_IDClienteAuto;
                    await _negozioRepository.AddAsync(negozio);
                }
                else
                {
                    _context.Entry(negozioEsistente).CurrentValues.SetValues(negozio);
                    await _negozioRepository.UpdateAsync(negozioEsistente);
                }
            }

            // **Gestione Moduli: Creazione e Associazione**

            // Ignoro tutti i moduli che hanno entrambe le date null
            var moduliAssociati = moduli.Where(m => (m.Item2.Mdc_DataAttivazione != null || m.Item2.Mdc_DataDisattivazione != null)).ToList();
            foreach (var modulo in moduliAssociati)
            {
                var moduloEsistente = await _moduloRepository.GetByIdAsync(modulo.Item1.Mde_IDAuto);
                if (moduloEsistente != null)
                {
                    // Controlla se l'associazione esiste già
                    var associazioneEsistente = await _moduloClienteRepository.GetByClienteAndModuloAsync(cliente.Utw_IDClienteAuto, moduloEsistente.Mde_IDAuto);
                    if (associazioneEsistente == null)
                    {
                        var moduloCliente = new DbModuloCliente
                        {
                            Mdc_IDCliente = cliente.Utw_IDClienteAuto,
                            Mdc_IDModulo = moduloEsistente.Mde_IDAuto,
                            Mdc_DataAttivazione = modulo.Item2.Mdc_DataAttivazione,
                            Mdc_DataDisattivazione = modulo.Item2.Mdc_DataDisattivazione,
                            Mdc_BloccoModulo = modulo.Item2.Mdc_BloccoModulo,
                            Mdc_DataOraBlocco = modulo.Item2.Mdc_DataOraBlocco,
                            Mdc_Nota = modulo.Item2.Mdc_Nota
                        };
                        await _moduloClienteRepository.AddAsync(moduloCliente);
                    }
                    else
                    {
                        modulo.Item2.Mdc_IDAuto = associazioneEsistente.Mdc_IDAuto;
                        modulo.Item2.Mdc_IDCliente = associazioneEsistente.Mdc_IDCliente;
                        _context.Entry(associazioneEsistente).CurrentValues.SetValues(modulo.Item2);
                        await _moduloClienteRepository.UpdateAsync(associazioneEsistente);
                    }
                }
            }

            // Salvataggio finale
            await _context.SaveChangesAsync();
        }


        public async Task<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<Tuple<DbModuloEasygold, DbModuloCliente>>? Moduli, List<DbAllegato>? Allegati, List<DbNegozi>? Negozi, DbNazioni? Nazione, DbValute? Valuta, DbStatoCliente? StatoCliente)>
        GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clienti
                .Where(c => c.Utw_IDClienteAuto == id)
                .FirstOrDefaultAsync();

            var datiCliente = await _context.DatiClienti
                .Where(d => d.Dtc_IDCliente == id)
                .FirstOrDefaultAsync();

            var moduli = (await _moduloClienteRepository.GetByClienteIdAsync(id)).ToList();

            var allegati = await _context.Allegati
                .Where(a => a.All_EntitaRiferimento == "Cliente" && a.All_RecordId == id)
                .ToListAsync();

            var negozi = await _context.Negozi
                .Where(n => n.Neg_IDCliente == id)
                .ToListAsync();

            var nazioni = await _context.Nazioni
                .Where(n => n.Naz_id == datiCliente.Dtc_Nazione)
                .FirstOrDefaultAsync();

            var valuta = await _context.Valute
                .Where(v => v.Val_id == datiCliente.Dtc_IDValuta)
                .FirstOrDefaultAsync();

            var statoCliente = await _context.StatiCliente
                .Where(sc => sc.Stc_id == cliente.Utw_IdStatoCliente)
                .FirstOrDefaultAsync();

            return (cliente, datiCliente, moduli, allegati, negozi, nazioni, valuta, statoCliente);
        }

        /// <summary>
        /// Elimina un allegato e rimuove il file associato.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clienti.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente non trovato.");
            }

            // ✅ Elimina Dati Cliente
            var datiCliente = await _context.DatiClienti
                .Where(d => d.Dtc_IDCliente == id)
                .ToListAsync();
            _context.DatiClienti.RemoveRange(datiCliente);

            // ✅ Elimina Moduli Cliente
            var moduliCliente = await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == id)
                .ToListAsync();
            _context.ModuloClienti.RemoveRange(moduliCliente);

            // ✅ Elimina Allegati Cliente
            var allegati = await _context.Allegati
                .Where(a => a.All_EntitaRiferimento == "Cliente" && a.All_RecordId == id)
                .ToListAsync();
            _context.Allegati.RemoveRange(allegati);

            // ✅ Elimina Negozi Cliente
            var negozi = await _context.Negozi
                .Where(n => n.Neg_IDCliente == id)
                .ToListAsync();
            _context.Negozi.RemoveRange(negozi);

            // ✅ Elimina il Cliente dopo aver rimosso i dati correlati
            _context.Clienti.Remove(cliente);

            // ✅ Salvataggio finale
            await _context.SaveChangesAsync();
        }
    }
}