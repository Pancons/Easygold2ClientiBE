using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models;
using EasyGold.API.Models.Utenti;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Variabili;

namespace EasyGold.API.Services.Implementations
{

    public class ValoriTabelleService : IValoriTabelleService
    {
        private readonly IValoriTabelleRepository _repo;
        private readonly IMapper _mapper;
        private readonly HttpClient _webhookClient;

        public ValoriTabelleService(
            IValoriTabelleRepository repo,
            IMapper mapper,
            IHttpClientFactory httpClientFactory)
        {
            _repo = repo;
            _mapper = mapper;
            _webhookClient = httpClientFactory.CreateClient("WebhookClient");
        }
        public async Task<BaseListResponse<ValoriTabelleDTO>> FindAsync(string lstItemType)
        {
            var data = await _repo.FindByItemTypeAsync(lstItemType);
            
            return new BaseListResponse<ValoriTabelleDTO>
            {
                results = _mapper.Map<IEnumerable<ValoriTabelleDTO>>(data).ToList(),
                total = data.Count()
            };
        
        }
           

        public async Task<ValoriTabelleDTO> SaveAsync(ValoriTabelleDTO dto)
        {
            DbValoriTabelle entity;

            if (dto.RowId.HasValue)
            {
                entity = await _repo.GetByIdAsync(dto.RowId.Value);
                if (entity == null)
                    throw new KeyNotFoundException("Record non trovato.");

                _mapper.Map(dto, entity);
                await _repo.UpdateAsync(entity);
            }
            else
            {
                entity = _mapper.Map<DbValoriTabelle>(dto);
                await _repo.InsertAsync(entity);
            }

            await NotifyWebhookAsync(dto);
            
            return _mapper.Map<ValoriTabelleDTO>(entity);
        }


        public async Task<bool> DeleteAsync(int id)
        {   
            DbValoriTabelle entity = await _repo.GetByIdAsync(id);
            ValoriTabelleDTO dto = _mapper.Map<ValoriTabelleDTO>(entity);
            await NotifyWebhookAsync(dto);
            return await _repo.DeleteAsync(id);
        }

        private async Task NotifyWebhookAsync(ValoriTabelleDTO dto)
        {
            try
            {
                var response = await _webhookClient.PostAsJsonAsync("api/ValoriTabelleWebhook/on-change", dto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Webhook failed: {ex.Message}");
            }
        }

        


    }
}