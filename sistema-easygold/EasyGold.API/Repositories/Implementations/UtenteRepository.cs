
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

          // Recupero lista utenti con filtri e paginazione
        public async Task<(IEnumerable<UtenteDTO> Users, int Total)> GetUsersListAsync(UserFilterDTO filter)
        {
            var query = _context.Utenti.AsQueryable();

            // Filtri
            if (filter.IDUtente.HasValue)
                query = query.Where(u => u.Ute_IDUtente == filter.IDUtente.Value);

            if (!string.IsNullOrEmpty(filter.Utw_Cognome))
                query = query.Where(u => u.Ute_Cognome.Contains(filter.Utw_Cognome));

            if (filter.Utw_IDRuolo.HasValue)
                query = query.Where(u => u.Ute_IDRuolo == filter.Utw_IDRuolo.Value);

            int total = await query.CountAsync();

            // Ordinamento dinamico
            if (filter.Sort != null && filter.Sort.Any())
            {
                foreach (var sortItem in filter.Sort)
                {
                    query = sortItem.Order.ToLower() == "asc"
                        ? query.OrderBy(u => EF.Property<object>(u, sortItem.Field))
                        : query.OrderByDescending(u => EF.Property<object>(u, sortItem.Field));
                }
            }

            // Paginazione
            var users = await query.Skip(filter.Offset).Take(filter.Limit)
                .Select(u => new UtenteDTO
                {
                    Ute_IDUtente = u.Ute_IDUtente,
                    Ute_Nome = u.Ute_Nome,
                    Ute_Cognome = u.Ute_Cognome,
                    Ute_NomeUtente = u.Ute_NomeUtente,
                    Ute_IDRuolo = u.Ute_IDRuolo,
                    Ute_Bloccato = u.Ute_Bloccato,
                    Ute_Nota = u.Ute_Nota,
                    Ute_Password = u.Ute_Password // Assicurati che sia già hashata nel DB
                }).ToListAsync();

            return (users, total);
        }

        // Recupero singolo utente
        public async Task<UtenteDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Utenti
                .Where(u => u.Ute_IDUtente == id)
                .Select(u => new UtenteDTO
                {
                    Ute_IDUtente = u.Ute_IDUtente,
                    Ute_Nome = u.Ute_Nome,
                    Ute_Cognome = u.Ute_Cognome,
                    Ute_NomeUtente = u.Ute_NomeUtente,
                    Ute_IDRuolo = u.Ute_IDRuolo,
                    Ute_Bloccato = u.Ute_Bloccato,
                    Ute_Nota = u.Ute_Nota,
                    Ute_Password = u.Ute_Password // Assicurati che sia già hashata nel DB
                })
                .FirstOrDefaultAsync();

            return user;
        }

    

        /*

        public async Task<IEnumerable<DbUtente>> GetAllAsync()
        {
            return await _context.Utenti.ToListAsync();
        }

        public async Task<DbUtente> GetByIdAsync(int id)
        {
            return await _context.Utenti.FindAsync(id);
        }

       

        public async Task DeleteAsync(int id)
        {
            var utente = await GetByIdAsync(id);
            if (utente != null)
            {
                _context.Utenti.Remove(utente);
                await _context.SaveChangesAsync();
            }
        }
*/
    }

}