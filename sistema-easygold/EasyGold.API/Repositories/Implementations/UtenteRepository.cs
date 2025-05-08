
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations
{
    public class UtenteRepository : IUtenteRepository
    {
        private readonly ApplicationDbContext _context;

        public UtenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DbUtente utente)
        {
            await _context.Utenti.AddAsync(utente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbUtente utente)
        {
            _context.Utenti.Update(utente);
            await _context.SaveChangesAsync();
        }
        
       public async Task<(IEnumerable<DbUtente> Users, int Total)> GetUsersListAsync(UtentiListRequest request)
        {
            var query = from u in _context.Utenti
                        join r in _context.Ruoli on u.Ute_IDRuolo equals r.Ur_IDRuolo
                        select new DbUtente
                        {
                            Ute_IDUtente = u.Ute_IDUtente,
                            Ute_Nome = u.Ute_Nome,
                            Ute_Cognome = u.Ute_Cognome,
                            Ute_NomeUtente = u.Ute_NomeUtente,
                            Ute_IDRuolo = u.Ute_IDRuolo,
                            Ute_Bloccato = u.Ute_Bloccato,
                            Ute_Nota = u.Ute_Nota,
                            Ute_Password = u.Ute_Password,
                            Ruolo = new DbRuolo
                            {
                                Ur_IDRuolo = r.Ur_IDRuolo,
                                Ur_Descrizione = r.Ur_Descrizione
                            }
                        };

            // Filtri
            if (request.Filters != null)
            {
                if (request.Filters.IDUtente.HasValue)
                    query = query.Where(u => u.Ute_IDUtente == request.Filters.IDUtente.Value);

                if (!string.IsNullOrEmpty(request.Filters.Utw_Cognome))
                    query = query.Where(u => u.Ute_Cognome.Contains(request.Filters.Utw_Cognome));

                if (request.Filters.Utw_IDRuolo.HasValue)
                    query = query.Where(u => u.Ute_IDRuolo == request.Filters.Utw_IDRuolo.Value);
            }

            int total = await query.CountAsync();

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<DbUtente>? orderedQuery = null;

                foreach (var sort in request.Sort)
                {
                    bool isValid = typeof(DbUtente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    if (!isValid) continue;
                    sort.Field = typeof(DbUtente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;

                    if (orderedQuery == null)
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? query.OrderBy(u => EF.Property<object>(u, sort.Field))
                            : query.OrderByDescending(u => EF.Property<object>(u, sort.Field));
                    }
                    else
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? orderedQuery.ThenBy(u => EF.Property<object>(u, sort.Field))
                            : orderedQuery.ThenByDescending(u => EF.Property<object>(u, sort.Field));
                    }
                }

                if (orderedQuery != null)
                    query = orderedQuery;
            }

            var utenti = await query
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync();

            return (utenti, total);
        }

        // Recupero singolo utente
        public async Task<DbUtente> GetUserByIdAsync(int id)
        {
            var utente = await _context.Utenti
                .Include(u => u.Ruolo) // ✅ include anche i dati del ruolo, se presenti
                .FirstOrDefaultAsync(u => u.Ute_IDUtente == id);

            // Lo sgancio da EF per evitare problemi in fase di aggiornamento
            _context.Entry(utente).State = EntityState.Detached;

            return utente;
        }

        public async Task<DbUtente> GetUserByUsernameAsync(string username)
        {
            var utente = await _context.Utenti
                .Include(u => u.Ruolo) // ✅ include anche i dati del ruolo, se presenti
                .FirstOrDefaultAsync(u => u.Ute_NomeUtente == username);

            // Lo sgancio da EF per evitare problemi in fase di aggiornamento
            _context.Entry(utente).State = EntityState.Detached;

            return utente;
        }

        // Verifica l'esistenza di un nome utente
        public async Task<bool> UsernameExist(string username)
        {
            return _context.Utenti.Any(u => u.Ute_NomeUtente == username);
        }

        /// <summary>
        /// Elimina un utente e rimuove il file associato.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var utente = await _context.Utenti.FindAsync(id);
            if (utente != null)
            {
                _context.Utenti.Remove(utente);
                await _context.SaveChangesAsync();
            }
        }        
    }

}