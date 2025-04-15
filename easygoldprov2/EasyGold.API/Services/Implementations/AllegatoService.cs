using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Allegati;
using AutoMapper;
using EasyGold.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Models;
using EasyGold.API.Models.Clienti;

namespace EasyGold.API.Services.Implementations
{
    public class AllegatoService : IAllegatoService
    {
        private readonly IAllegatoRepository _allegatoRepository;
        private readonly IMapper _mapper;

        public AllegatoService(IAllegatoRepository allegatoRepository, IMapper mapper)
        {
            _allegatoRepository = allegatoRepository;
            _mapper = mapper;
        }

        public async Task<BaseListResponse<AllegatoDTO>> GetAllAsync()
        {
            var allegati = await _allegatoRepository.GetAllAsync();
            return new BaseListResponse<AllegatoDTO>
            {
                results = _mapper.Map<IEnumerable<AllegatoDTO>>(allegati).ToList(),  // ? Mappa automaticamente senza "N/A"
                total = allegati.Count()
            };
        }

        public async Task<AllegatoDTO> GetByIdAsync(int id)
        {
            var allegato = await _allegatoRepository.GetByIdAsync(id);
            return _mapper.Map<AllegatoDTO>(allegato);
        }

        public async Task<AllegatoDTO> AddAsync(AllegatoDTO allegatoDto)
        {
            var allegato = _mapper.Map<DbAllegato>(allegatoDto);
            await _allegatoRepository.AddAsync(allegato);
            allegatoDto = _mapper.Map<AllegatoDTO>(allegato);
            return allegatoDto;
        }

        public async Task<AllegatoDTO> UpdateAsync(AllegatoDTO allegatoDto)
        {
            var allegato = _mapper.Map<DbAllegato>(allegatoDto);
            await _allegatoRepository.UpdateAsync(allegato);
            allegatoDto = _mapper.Map<AllegatoDTO>(allegato);
            return allegatoDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _allegatoRepository.DeleteAsync(id);
        }

        public async Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath)
        {
            return await _allegatoRepository.GetFileByPathAsync(filePath);
        }
    }


}