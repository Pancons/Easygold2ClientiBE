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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class QuotazioneMetalliService : IQuotazioneMetalliService
    {
        private readonly IQuotazioneMetalliRepository _repository;

        public QuotazioneMetalliService(IQuotazioneMetalliRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<QuotazioneMetalliDTO>> GetAllAsync(QuotazioneMetalliListRequest request)
        {
            var (items, total) = await _repository.GetAllAsync(request);
            var dtos = items.Select(MapToDto).ToList();
            return new BaseListResponse<QuotazioneMetalliDTO>(dtos, total);
        }

        public async Task<QuotazioneMetalliDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<QuotazioneMetalliDTO> AddAsync(QuotazioneMetalliDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<QuotazioneMetalliDTO> UpdateAsync(QuotazioneMetalliDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.mqt_IDAuto);
            if (entity == null) return null;

            entity.Mqt_Acquisto = dto.mqt_acquisto;
            entity.Mqt_VenditaFino = dto.mqt_venditaFino;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private QuotazioneMetalliDTO MapToDto(DbQuotazioneMetalli entity)
        {
            return new QuotazioneMetalliDTO
            {
                mqt_IDAuto = entity.Mqt_IDAuto,
                mqt_ID = entity.Mqt_ID,
                mqt_acquisto = entity.Mqt_Acquisto,
                mqt_venditaFino = entity.Mqt_VenditaFino
            };
        }

        private DbQuotazioneMetalli MapToEntity(QuotazioneMetalliDTO dto)
        {
            return new DbQuotazioneMetalli
            {
                Mqt_IDAuto = dto.mqt_IDAuto,
                Mqt_ID = dto.mqt_ID,
                Mqt_Acquisto = dto.mqt_acquisto,
                Mqt_VenditaFino = dto.mqt_venditaFino
            };
        }
    }
}