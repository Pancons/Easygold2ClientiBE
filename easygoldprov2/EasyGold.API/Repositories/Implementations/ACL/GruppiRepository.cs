using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class GruppiRepository : IGruppiRepository
    {
        private readonly ApplicationDbContext _context;

        public GruppiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbGruppi>, int total)> GetAllAsync(GruppiListRequest filter, string language)
        {
            var query = _context.Gruppi
                .Include(g => g.GruppiLang)
                .Where(g => g.GruppiLang.Any(gl => gl.grpid_ISONum.ToString() == language))
                .AsQueryable();


            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbGruppi> GetByIdAsync(int id, string language)
        {
            return await _context.Gruppi
                .Include(g => g.GruppiLang)
                .SingleOrDefaultAsync(g => g.Grp_IDAuto == id && g.GruppiLang.Any(gl => gl.grpid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbGruppi entity, string language)
        {
            if (language == "39")
            {
                // Italiano: inserisci nella tabella principale
                await _context.Gruppi.AddAsync(entity);
            }
            else
            {
                // Lingua diversa: inserisci il gruppo base (per ottenere ID)
                var baseEntity = new DbGruppi();
                await _context.Gruppi.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.GruppiLang?.FirstOrDefault(gl => gl.grpid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.grpid_ID = baseEntity.Grp_IDAuto;
                    _context.GruppiLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbGruppi entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorna direttamente la tabella principale
                _context.Gruppi.Update(entity);
            }
            else
            {
                var lang = entity.GruppiLang?.FirstOrDefault(gl => gl.grpid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.GruppiLang
                        .FirstOrDefaultAsync(gl =>
                            gl.grpid_ID == entity.Grp_IDAuto &&
                            gl.grpid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.grpid_nomeGruppo = lang.grpid_nomeGruppo;
                        existingLang.grpid_desGruppo = lang.grpid_desGruppo;
                        _context.GruppiLang.Update(existingLang);
                    }
                    else
                    {
                        lang.grpid_ID = entity.Grp_IDAuto;
                        _context.GruppiLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Gruppi.FindAsync(id);
            if (entity != null)
            {
                _context.Gruppi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}