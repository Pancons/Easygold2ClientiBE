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

        public ValoriTabelleService(IValoriTabelleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValoriTabelleDTO>> FindAsync(string lstItemType)
        {
            var data = await _repo.FindByItemTypeAsync(lstItemType);
            return _mapper.Map<IEnumerable<ValoriTabelleDTO>>(data);
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

            return _mapper.Map<ValoriTabelleDTO>(entity);
        }
    }
}