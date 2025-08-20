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
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class DocumentiFunzioneRepository : IDocumentiFunzioneRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentiFunzioneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbDocumentiFunzione>, int total)> GetAllAsync(DocumentiFunzioneListRequest filter)
        {
            var query = _context.DocumentiFunzione.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbDocumentiFunzione> GetByIdAsync(int id)
        {
            return await _context.DocumentiFunzione.FindAsync(id);
        }

        public async Task AddAsync(DbDocumentiFunzione entity)
        {
            await _context.DocumentiFunzione.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbDocumentiFunzione entity)
        {
            _context.DocumentiFunzione.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DocumentiFunzione.FindAsync(id);
            if (entity != null && !entity.Dof_Annulla) // Ensure document is not flagged as canceled
            {
                _context.DocumentiFunzione.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}