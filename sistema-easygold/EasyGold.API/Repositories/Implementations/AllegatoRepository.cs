using System.Collections.Generic;
using System.Linq;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories
{
public class AllegatoRepository : IAllegatoRepository
    {
        private readonly List<DbAllegato> _allegati = new List<DbAllegato>();

        public async Task<IEnumerable<DbAllegato>> GetAllAsync()
        {
            return await Task.FromResult(_allegati);
        }

        public async Task<DbAllegato> GetByIdAsync(int id)
        {
            return await Task.FromResult(_allegati.FirstOrDefault(a => a.All_IDAllegato == id));
        }

        public async Task AddAsync(DbAllegato allegato)
        {
            _allegati.Add(allegato);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(DbAllegato allegato)
        {
            var existing = await GetByIdAsync(allegato.All_IDAllegato);
            if (existing != null)
            {
                _allegati.Remove(existing);
                _allegati.Add(allegato);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var allegato = await GetByIdAsync(id);
            if (allegato != null)
            {
                _allegati.Remove(allegato);
            }
        }
    }
}
