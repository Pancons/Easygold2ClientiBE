using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class NazioneRepository : INazioneRepository
    {
        private readonly ApplicationDbContext _context;

        public NazioneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNazioni>> GetAllAsync(NazioniListRequest request)
        {
            var query = from nazioni in _context.Nazioni select nazioni;

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<DbNazioni>? orderedQuery = null;

                foreach (var sort in request.Sort)
                {
                    bool isValid = typeof(DbNazioni).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    if (!isValid) continue;
                    sort.Field = typeof(DbNazioni).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;

                    if (orderedQuery == null)
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? query.OrderBy(nazioni => EF.Property<object>(nazioni, sort.Field))
                            : query.OrderByDescending(nazioni => EF.Property<object>(nazioni, sort.Field));
                    }
                    else
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? orderedQuery.ThenBy(nazioni => EF.Property<object>(nazioni, sort.Field))
                            : orderedQuery.ThenByDescending(nazioni => EF.Property<object>(nazioni, sort.Field));
                    }
                }

                if (orderedQuery != null)
                    query = orderedQuery;
            }

            var result = await query
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync();

            return result;
        }

        public async Task<DbNazioni> GetByIdAsync(int id)
        {
            return await _context.Nazioni.FindAsync(id);
        }
    }
}
