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
    public class TestataPostazioniRepository : ITestataPostazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public TestataPostazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTestataPostazioni> items, int total)> GetAllAsync(TestataPostazioniListRequest request)
        {
            var query = _context.TestataPostazioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbTestataPostazioni> GetByIdAsync(int id)
        {
            var entity = await _context.TestataPostazioni.FindAsync(id);
            return entity == null ? null : new DbTestataPostazioni
            {
                tpo_IDAuto = entity.tpo_IDAuto,
                tpo_descizione = entity.tpo_descizione,
                tpo_registratore = entity.tpo_registratore,
                tpo_stampanti = entity.tpo_stampanti,
                tpo_card = entity.tpo_card,
                tpo_annullato = entity.tpo_annullato,
                StampePostazioni = entity.StampePostazioni.Select(sp => new DbStampePostazioni
                {
                    Tpo_IDAuto = sp.Tpo_IDAuto,
                    Tpo_IDPostazione = sp.Tpo_IDPostazione,
                    Tpo_IDStampa = sp.Tpo_IDStampa,
                    Tpo_IPDevice = sp.Tpo_IPDevice,
                    Tpo_Device = sp.Tpo_Device,
                    Tpo_Diretta = sp.Tpo_Diretta,
                    Tpo_Annullato = sp.Tpo_Annullato
                }).ToList(),
                FiscalePostazioni = entity.FiscalePostazioni.Select(fp => new DbFiscalePostazioni
                {
                    Fpo_IDAuto = fp.Fpo_IDAuto,
                    Fpo_IDPostazione = fp.Fpo_IDPostazione,
                    Fpo_IDRegFiscale = fp.Fpo_IDRegFiscale,
                    Fpo_IPPath = fp.Fpo_IPPath,
                    Fpo_Attivo = fp.Fpo_Attivo,
                    Fpo_Annullato = fp.Fpo_Annullato
                }).ToList(),
                LettorePostazioni = entity.LettorePostazioni.Select(lp => new DbLettorePostazioni
                {
                    Lpo_IDAuto = lp.Lpo_IDAuto,
                    Lpo_IDPostazione = lp.Lpo_IDPostazione,
                    Lpo_IDLettore = lp.Lpo_IDLettore,
                    Lpo_Annullato = lp.Lpo_Annullato
                }).ToList()
            };
        }

        public async Task AddAsync(DbTestataPostazioni entity)
        {
            await _context.TestataPostazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task<DbTestataPostazioni> UpdateAsync(DbTestataPostazioni entity)
        {
           
            _context.TestataPostazioni.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TestataPostazioni.FindAsync(id);
            if (entity != null)
            {
                _context.TestataPostazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}