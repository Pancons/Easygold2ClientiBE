using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Allegati;
using EasyGold.Web2.Models.Cliente.Entities.Allegati;
using EasyGold.API.Services.Interfaces.Allegati;
using EasyGold.API.Repositories.Interfaces.Allegati;

namespace EasyGold.API.Services.Implementations.Allegati
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
            return new BaseListResponse<AllegatoDTO>(_mapper.Map<IEnumerable<AllegatoDTO>>(allegati).ToList(), allegati.Count());
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