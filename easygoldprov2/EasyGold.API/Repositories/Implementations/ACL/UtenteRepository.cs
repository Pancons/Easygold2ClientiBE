using EasyGold.API.Infrastructure;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.ACL
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

        public async Task<(IEnumerable<DbUtente> Users, int Total)> GetAllAsync(BaseListRequest request)
        {
            var query = from u in _context.Utenti
                        select new DbUtente
                        {
                            Ute_IDAuto = u.Ute_IDAuto,
                            Ute_IDUtente = u.Ute_IDUtente,
                            Ute_NomeUtente = u.Ute_NomeUtente,
                            Ute_IDGruppo = u.Ute_IDGruppo,
                            Ute_IDIdioma = u.Ute_IDIdioma,
                            Ute_AbilitaTuttiNegozi = u.Ute_AbilitaTuttiNegozi,
                            Ute_AbilitaCassa = u.Ute_AbilitaCassa,
                            Ute_AbilitaEliminaProd = u.Ute_AbilitaEliminaProd,
                            Ute_Bloccato = u.Ute_Bloccato
                        };

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

        public async Task<DbUtente> GetByIdAsync(int id)
        {
            return await _context.Utenti
                .FirstOrDefaultAsync(u => u.Ute_IDAuto == id);
        }

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