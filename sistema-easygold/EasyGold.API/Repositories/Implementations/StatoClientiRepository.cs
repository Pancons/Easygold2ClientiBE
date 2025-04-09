using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.StatiCliente;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class StatoClientiRepository : IStatoClientiRepository
    {
        private readonly ApplicationDbContext _context;

        public StatoClientiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbStatoCliente>> GetAllAsync(StatoClienteListRequest request)
        {
            var query = from statiCliente in _context.StatiCliente select statiCliente;

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<DbStatoCliente>? orderedQuery = null;

                foreach (var sort in request.Sort)
                {
                    bool isValid = typeof(DbStatoCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    if (!isValid) continue;
                    sort.Field = typeof(DbStatoCliente).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;

                    if (orderedQuery == null)
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? query.OrderBy(statiCliente => EF.Property<object>(statiCliente, sort.Field))
                            : query.OrderByDescending(statiCliente => EF.Property<object>(statiCliente, sort.Field));
                    }
                    else
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? orderedQuery.ThenBy(statiCliente => EF.Property<object>(statiCliente, sort.Field))
                            : orderedQuery.ThenByDescending(statiCliente => EF.Property<object>(statiCliente, sort.Field));
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

        public async Task<DbStatoCliente> GetByIdAsync(int id)
        {
            return await _context.StatiCliente.FindAsync(id);
        }
    }
}
