using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
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

        public async Task<IEnumerable<DbNazioni>> GetAllAsync()
        {
            return await _context.Nazioni.ToListAsync();
        }

        public async Task<DbNazioni> GetByIdAsync(int id)
        {
            return await _context.Nazioni.FindAsync(id);
        }
    }
}
