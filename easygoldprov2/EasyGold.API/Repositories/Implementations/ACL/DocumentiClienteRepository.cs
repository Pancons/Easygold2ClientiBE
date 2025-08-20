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
    public class DocumentiClienteRepository : IDocumentiClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentiClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbDocumentiCliente> items, int total)> GetAllAsync(DocumentiClienteListRequest request)
        {
            var query = _context.DocumentiCliente.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbDocumentiCliente> GetByIdAsync(int id)
        {
            return await _context.DocumentiCliente.FindAsync(id);
        }

        public async Task AddAsync(DbDocumentiCliente entity)
        {
            await _context.DocumentiCliente.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbDocumentiCliente> UpdateAsync(DbDocumentiCliente entity)
        {
            _context.DocumentiCliente.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DocumentiCliente.FindAsync(id);
            if (entity != null && !entity.Doc_Annulla) // Check if not canceled
            {
                _context.DocumentiCliente.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}