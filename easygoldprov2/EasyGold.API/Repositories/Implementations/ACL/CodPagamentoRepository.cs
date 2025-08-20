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
    public class CodPagamentoRepository : ICodPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public CodPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCodPagamento>, int total)> GetAllAsync(CodPagamentoListRequest filter, string language)
        {
            var query = _context.CodPagamenti
                .Include(c => c.CodPagamentoLang)
                .Where(c => c.CodPagamentoLang.Any(cl => cl.CpaId_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCodPagamento> GetByIdAsync(int id, string language)
        {
            return await _context.CodPagamenti
                .Include(c => c.CodPagamentoLang)
                .SingleOrDefaultAsync(c => c.Cpa_IDAuto == id && c.CodPagamentoLang.Any(cl => cl.CpaId_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCodPagamento entity, string language)
        {
            if (language == "39")
            {
                // Italiano: inserisci nella tabella principale
                await _context.CodPagamenti.AddAsync(entity);
            }
            else
            {
                // Lingua diversa: inserisci la condizione base (per ottenere ID)
                var baseEntity = new DbCodPagamento
                {
                    Cpa_Descrizione = entity.Cpa_Descrizione,
                    Cpa_PartenzaMese = entity.Cpa_PartenzaMese,
                    Cpa_NumMesi = entity.Cpa_NumMesi,
                    Cpa_MeseCommerciale = entity.Cpa_MeseCommerciale,
                    Cpa_Annullato = entity.Cpa_Annullato
                };

                await _context.CodPagamenti.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.CodPagamentoLang?.FirstOrDefault(cl => cl.CpaId_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.CpaId_ID = baseEntity.Cpa_IDAuto;
                    _context.CodPagamentoLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCodPagamento entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorna direttamente la tabella principale
                _context.CodPagamenti.Update(entity);
            }
            else
            {
                var lang = entity.CodPagamentoLang?.FirstOrDefault(cl => cl.CpaId_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.CodPagamentoLang
                        .FirstOrDefaultAsync(cl =>
                            cl.CpaId_ID == entity.Cpa_IDAuto &&
                            cl.CpaId_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.CpaId_Descrizione = lang.CpaId_Descrizione;
                        _context.CodPagamentoLang.Update(existingLang);
                    }
                    else
                    {
                        lang.CpaId_ID = entity.Cpa_IDAuto;
                        _context.CodPagamentoLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CodPagamenti.FindAsync(id);
            if (entity != null)
            {
                _context.CodPagamenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}