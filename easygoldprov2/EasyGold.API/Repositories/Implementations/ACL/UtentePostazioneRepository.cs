using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class UtentePostazioneRepository : IUtentePostazioneRepository
    {
        private readonly ApplicationDbContext _context;

        public UtentePostazioneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbUtentePostazione> items, int total)> GetAllAsync(UtentePostazioneListRequest request)
        {
            var query = _context.UtentePostazioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbUtentePostazione> GetByIdAsync(int id)
        {
            var entity = await _context.UtentePostazioni.FindAsync(id);
            return entity == null ? null : new DbUtentePostazione
            {
                Upo_IDAuto = entity.Upo_IDAuto,
                Upo_IdUtente_IDNegozio = entity.Upo_IdUtente_IDNegozio,
                Upo_IDPostazione = entity.Upo_IDPostazione,
                Upo_Annullato = entity.Upo_Annullato
            };
        }

        public async Task AddAsync(DbUtentePostazione entity)
        {
           
            await _context.UtentePostazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
       
        }

        public async Task<DbUtentePostazione> UpdateAsync(DbUtentePostazione entity)
        {
            _context.UtentePostazioni.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UtentePostazioni.FindAsync(id);
            if (entity != null)
            {
                _context.UtentePostazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}