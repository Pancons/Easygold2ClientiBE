using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;

using EasyGold.API.Models.DTO.Moduli;
using AutoMapper;
using EasyGold.API.Models;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Services.Clients;
using EasyGold.API.Models.DTO.Variabili;

namespace EasyGold.API.Services.Implementations.ConfigData
{
    public class CachedValoriTabelleService
    {
        private readonly ValoriTabelleApiClient _apiClient;
        private List<ValoriTabelleDTO> _cachedValues;
        private DateTime _lastUpdate;

        public CachedValoriTabelleService(ValoriTabelleApiClient apiClient)
        {
            _apiClient = apiClient;
            _cachedValues = new List<ValoriTabelleDTO>();
            _lastUpdate = DateTime.MinValue;
        }

        public async Task<IEnumerable<ValoriTabelleDTO>> GetValuesAsync(string lstItemType)
        {
            // Se la cache è vuota o scaduta, aggiorna i valori
            if (!_cachedValues.Any() || IsCacheExpired())
            {
                await UpdateCache(lstItemType);
            }

            return _cachedValues.Where(v => v.LstItemType == lstItemType);
        }

        public async Task UpdateCache(string lstItemType)
        {
            var latestValues = await _apiClient.List(lstItemType);
            _cachedValues = latestValues.ToList();
            _lastUpdate = DateTime.UtcNow;
        }

        private bool IsCacheExpired()
        {
            // Cache valida per esempio per 1 ora
            return (DateTime.UtcNow - _lastUpdate).TotalHours > 1;
        }

        // Metodo richiamato dal webhook per aggiornamento forzato
        public async Task ForceCacheRefreshAsync(string lstItemType)
        {
            await UpdateCache(lstItemType);
        }
    }
}