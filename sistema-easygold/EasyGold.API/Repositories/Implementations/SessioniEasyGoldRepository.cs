using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class SessioniEasyGoldRepository : ISessioniEasyGoldRepository
    {
        private readonly ApplicationDbContext _context;

        public SessioniEasyGoldRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbSessioniEasyGold> items, int total)> GetAllAsync(SessioniEasyGoldListRequest request)
        {
            var query = from s in _context.SessioniEasyGold
                        select new DbSessioniEasyGold
                        {
                            Sse_IDAuto = s.Sse_IDAuto,
                            Sse_IDCliente = s.Sse_IDCliente,
                            Sse_IDUtente = s.Sse_IDUtente,
                            Sse_DataLogin = s.Sse_DataLogin,
                            Sse_SesScaduta = s.Sse_SesScaduta,
                            Sse_DataLogout = s.Sse_DataLogout,
                            Sse_sesForzata = s.Sse_sesForzata,
                            Sse_DataLogoutForzato = s.Sse_DataLogoutForzato
                        };
            int total = await query.CountAsync();
            if (request.Sort != null && request.Sort.Any())
            {
                IOrderedQueryable<DbSessioniEasyGold>? orderedQuery = null;
                foreach (var sort in request.Sort)
                {
                    bool isValid = typeof(DbSessioniEasyGold).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) != null;
                    if (!isValid) continue;
                    sort.Field = typeof(DbSessioniEasyGold).GetProperty(sort.Field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Name;
                    if (orderedQuery == null)
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? query.OrderBy(s => EF.Property<object>(s, sort.Field))
                            : query.OrderByDescending(s => EF.Property<object>(s, sort.Field));
                    }
                    else
                    {
                        orderedQuery = sort.Order.ToLower() == "asc"
                            ? orderedQuery.ThenBy(s => EF.Property<object>(s, sort.Field))
                            : orderedQuery.ThenByDescending(s => EF.Property<object>(s, sort.Field));
                    }
                }
                if (orderedQuery != null)
                    query = orderedQuery;
            }
            var sessions = await query
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync();
            return (sessions, total);
        }

        public async Task<DbSessioniEasyGold> GetByIdAsync(int id)
        {
            return await _context.SessioniEasyGold
                .FirstOrDefaultAsync(s => s.Sse_IDAuto == id);
        }

        public async Task AddAsync(DbSessioniEasyGold entity)
        {
            await _context.SessioniEasyGold.AddAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task<DbSessioniEasyGold> UpdateAsync(DbSessioniEasyGold entity)
        {
            _context.SessioniEasyGold.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var session = await _context.SessioniEasyGold.FindAsync(id);
            if (session != null)
            {
                _context.SessioniEasyGold.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}