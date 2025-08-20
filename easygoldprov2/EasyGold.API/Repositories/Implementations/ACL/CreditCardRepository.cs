using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCreditCard>, int total)> GetAllAsync(CreditCardListRequest filter, string language)
        {
            var query = _context.CreditCards
                .Include(c => c.CreditCardLangs)
                .Where(c => c.CreditCardLangs.Any(cl => cl.CrcId_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCreditCard> GetByIdAsync(int id, string language)
        {
            return await _context.CreditCards
                .Include(c => c.CreditCardLangs)
                .SingleOrDefaultAsync(c => c.Crc_IDAuto == id && c.CreditCardLangs.Any(cl => cl.CrcId_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCreditCard entity, string language)
        {
            if (language == "39")
            {
                // Se la lingua è l'italiano (codice 39), inserisci nella tabella principale
                await _context.CreditCards.AddAsync(entity);
            }
            else
            {
                // Altrimenti, inserisci la base e le traduzioni se esistono
                var baseEntity = new DbCreditCard
                {
                    Crc_Card = entity.Crc_Card,
                    Crc_Fee = entity.Crc_Fee,
                    Crc_Ordinamento = entity.Crc_Ordinamento,
                    Crc_Annulla = entity.Crc_Annulla
                };
                
                await _context.CreditCards.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var langEntity = entity.CreditCardLangs?.FirstOrDefault(cl => cl.CrcId_ISONum.ToString() == language);
                if (langEntity != null)
                {
                    langEntity.CrcId_ID = baseEntity.Crc_IDAuto;
                    _context.CreditCardLangs.Add(langEntity);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCreditCard entity, string language)
        {
            if (language == "39")
            {
                // Se la lingua è l'italiano (codice 39), aggiorna direttamente la tabella principale
                _context.CreditCards.Update(entity);
            }
            else
            {
                var langEntity = entity.CreditCardLangs?.FirstOrDefault(cl => cl.CrcId_ISONum.ToString() == language);
                if (langEntity != null)
                {
                    var existingLang = await _context.CreditCardLangs
                        .FirstOrDefaultAsync(cl =>
                            cl.CrcId_ID == entity.Crc_IDAuto &&
                            cl.CrcId_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.CrcId_Brand = langEntity.CrcId_Brand;
                        _context.CreditCardLangs.Update(existingLang);
                    }
                    else
                    {
                        langEntity.CrcId_ID = entity.Crc_IDAuto;
                        _context.CreditCardLangs.Add(langEntity);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CreditCards.FindAsync(id);
            if (entity != null)
            {
                _context.CreditCards.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}