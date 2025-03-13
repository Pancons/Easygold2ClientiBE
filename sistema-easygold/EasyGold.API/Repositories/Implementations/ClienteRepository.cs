using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Clienti;
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

        public async Task<(IEnumerable<(DbCliente Cliente, DbDatiCliente? DatiCliente)> Clienti, int Total)> 
            GetClientiAsync(ClienteFilter filters, int offset, int limit, string sortField, string sortOrder)
        {
            var query = from cliente in _context.Clienti
                        join datiCliente in _context.DatiClienti
                        on cliente.Utw_IDClienteAuto equals datiCliente.Dtc_IDCliente into clientiGroup
                        from datiCliente in clientiGroup.DefaultIfEmpty() // ✅ Permette datiCliente null
                        where (filters == null || string.IsNullOrEmpty(filters.DtcRagioneSociale) || datiCliente.Dtc_RagioneSociale.Contains(filters.DtcRagioneSociale))
                        && (filters == null || string.IsNullOrEmpty(filters.DtcGioielleria) || datiCliente.Dtc_Gioielleria.Contains(filters.DtcGioielleria))
                        && (filters == null || !filters.NonAttivi.HasValue || (filters.NonAttivi.Value && cliente.Utw_DataDisattivazione != null))
                        && (filters == null || !filters.Scaduti.HasValue || (filters.Scaduti.Value && cliente.Utw_DataAttivazione < DateTime.UtcNow.AddYears(-1)))
                        select new { Cliente = cliente, DatiCliente = datiCliente };

            // Conteggio totale dei risultati prima della paginazione
            int total = await query.CountAsync();

            // ✅ Verifica che il campo di ordinamento esista in entrambe le tabelle
            if (!string.IsNullOrEmpty(sortField))
            {
                bool isClienteField = typeof(DbCliente).GetProperty(sortField) != null;
                bool isDatiClienteField = typeof(DbDatiCliente).GetProperty(sortField) != null;

                if (isClienteField)
                {
                    query = sortOrder?.ToLower() == "asc"
                        ? query.OrderBy(c => EF.Property<object>(c.Cliente, sortField))
                        : query.OrderByDescending(c => EF.Property<object>(c.Cliente, sortField));
                }
                else if (isDatiClienteField)
                {
                    query = sortOrder?.ToLower() == "asc"
                        ? query.OrderBy(c => EF.Property<object>(c.DatiCliente, sortField))
                        : query.OrderByDescending(c => EF.Property<object>(c.DatiCliente, sortField));
                }
            }

            // Paginazione (Skip & Take)
            var clienti = await query.Skip(offset).Take(limit).ToListAsync();

            // ✅ Converte la lista di oggetti anonimi in una tupla di entità
            var result = clienti.Select(x => (x.Cliente, x.DatiCliente)).ToList();

            return (result, total);
        }

        public async Task AddClienteAsync(
            DbCliente cliente, 
            DbDatiCliente datiCliente, 
            List<DbModuloCliente> moduli, 
            List<DbAllegato> allegati, 
            List<DbNegozi> negozi)
        {
            // Aggiunta del cliente
            await _context.Clienti.AddAsync(cliente);
            await _context.SaveChangesAsync(); // Necessario per generare l'ID del cliente

            // Assegnazione dell'ID cliente agli altri oggetti prima di salvarli
            
            moduli.ForEach(m => m.Mdc_IDCliente = cliente.Utw_IDClienteAuto);
            allegati.ForEach(a => a.All_RecordId = cliente.Utw_IDClienteAuto);
            negozi.ForEach(n => n.Neg_IDCliente = cliente.Utw_IDClienteAuto);

            // Aggiunta dei dati cliente
            await _context.DatiClienti.AddAsync(datiCliente);

            // Aggiunta dei moduli associati
            if (moduli.Any())
                await _context.ModuloClienti.AddRangeAsync(moduli);

            // Aggiunta degli allegati associati
            if (allegati.Any())
                await _context.Allegati.AddRangeAsync(allegati);

            // Aggiunta dei negozi associati
            if (negozi.Any())
                await _context.Negozi.AddRangeAsync(negozi);

            // Salvataggio delle modifiche nel database
            await _context.SaveChangesAsync();
        }


        public async Task UpdateClienteAsync(
            DbCliente cliente, 
            DbDatiCliente datiCliente, 
            List<DbModuloCliente> moduli, 
            List<DbAllegato> allegati, 
            List<DbNegozi> negozi)
        {
            // Verifica se il cliente esiste
            var clienteEsistente = await _context.Clienti.FindAsync(cliente.Utw_IDClienteAuto);
            if (clienteEsistente == null)
                throw new KeyNotFoundException("Cliente non trovato.");

            // Aggiornamento delle proprietà del cliente
            _context.Entry(clienteEsistente).CurrentValues.SetValues(cliente);

            // Aggiornamento dei dati cliente
            var datiClienteEsistenti = await _context.DatiClienti
                .FirstOrDefaultAsync(d => d.Dtc_IDCliente == cliente.Utw_IDClienteAuto);
            
            if (datiClienteEsistenti != null)
                _context.Entry(datiClienteEsistenti).CurrentValues.SetValues(datiCliente);
            else
                await _context.DatiClienti.AddAsync(datiCliente); // Se non esiste, lo aggiunge

            // **Gestione dei moduli associati**
            var moduliEsistenti = await _context.ModuloClienti
                .Where(m => m.Mdc_IDCliente == cliente.Utw_IDClienteAuto)
                .ToListAsync();
            
            _context.ModuloClienti.RemoveRange(moduliEsistenti); // Rimuove quelli esistenti
            await _context.ModuloClienti.AddRangeAsync(moduli); // Aggiunge quelli nuovi

            // **Gestione degli allegati associati**
            var allegatiEsistenti = await _context.Allegati
                .Where(a => a.All_RecordId == cliente.Utw_IDClienteAuto && a.All_EntitaRiferimento == "Cliente")
                .ToListAsync();
            
            _context.Allegati.RemoveRange(allegatiEsistenti); // Rimuove quelli esistenti
            await _context.Allegati.AddRangeAsync(allegati); // Aggiunge quelli nuovi

            // **Gestione dei negozi associati**
            var negoziEsistenti = await _context.Negozi
                .Where(n => n.Neg_IDCliente == cliente.Utw_IDClienteAuto)
                .ToListAsync();
            
            _context.Negozi.RemoveRange(negoziEsistenti); // Rimuove quelli esistenti
            await _context.Negozi.AddRangeAsync(negozi); // Aggiunge quelli nuovi

            // Salvataggio delle modifiche
            await _context.SaveChangesAsync();
        }

        
        public async Task<(DbCliente Cliente, DbDatiCliente? DatiCliente, List<DbModuloEasygold> Moduli, List<DbAllegato> Allegati, List<DbNegozi> Negozi)> 
        GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clienti
                .Where(c => c.Utw_IDClienteAuto == id)
                .FirstOrDefaultAsync();

            var datiCliente = await _context.DatiClienti
                .Where(d => d.Dtc_IDCliente == id)
                .FirstOrDefaultAsync();

            var moduli = await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == id)
                .Join(_context.ModuloEasygold,
                    mc => mc.Mdc_IDModulo,
                    me => me.Mde_IDAuto,
                    (mc, me) => me)
                .ToListAsync();

            var allegati = await _context.Allegati
                .Where(a => a.All_EntitaRiferimento == "Cliente" && a.All_RecordId == id)
                .ToListAsync();

            var negozi = await _context.Negozi
                .Where(n => n.Neg_id == id)
                .ToListAsync();

            return (cliente, datiCliente, moduli, allegati, negozi);
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