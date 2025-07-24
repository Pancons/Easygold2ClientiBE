using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Valute;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class ValutaRepository : IValutaRepository
    {
        private readonly ApplicationDbContext _context;

        public ValutaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbValuta>> GetAllAsync(ValuteListRequest request)
        {
            var query = from valute in _context.Valute select valute;

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<DbValuta>? orderedQuery = null;

                foreach (var sort in request.Sort)
                {
                    bool isValid = typeof(DbValuta).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    if (!isValid) continue;
                    sort.Field = typeof(DbValuta).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;

                    if (orderedQuery == null)
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? query.OrderBy(valute => EF.Property<object>(valute, sort.Field))
                            : query.OrderByDescending(valute => EF.Property<object>(valute, sort.Field));
                    }
                    else
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? orderedQuery.ThenBy(valute => EF.Property<object>(valute, sort.Field))
                            : orderedQuery.ThenByDescending(valute => EF.Property<object>(valute, sort.Field));
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

        public async Task<DbValuta> GetByIdAsync(int id)
        {
            return await _context.Valute.FindAsync(id);
        }
    }
}
