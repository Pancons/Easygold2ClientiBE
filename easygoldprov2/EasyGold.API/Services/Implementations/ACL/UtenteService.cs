using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.Web2.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Allegati;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IMapper _mapper;

        public UtenteService(IUtenteRepository utenteRepository, IMapper mapper)
        {
            _utenteRepository = utenteRepository;
            _mapper = mapper;
        }

        public async Task<BaseListResponse<UtenteDTO>> GetUsersListAsync(UtentiListRequest filter)
        {
            var (utentiData, total) = await _utenteRepository.GetUsersListAsync(filter);
            return new BaseListResponse<UtenteDTO>
            {
                results = _mapper.Map<IEnumerable<UtenteDTO>>(utentiData).ToList(),  // ? Mappa automaticamente senza "N/A"
                total = total
            };
        }

        public async Task<UtenteDTO> GetUserByIdAsync(int id)
        {
            var utenteDettaglioDto = await _utenteRepository.GetUserByIdAsync(id);
            return _mapper.Map<UtenteDTO>(utenteDettaglioDto);

        }

        public async Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);

            // 🔹 Cripta la password prima di salvare l'utente
            utente.Ute_Password = BCrypt.Net.BCrypt.HashPassword(utenteDettaglioDto.Ute_Password);

            await _utenteRepository.AddAsync(utente);
            return utenteDettaglioDto;
        }


        public async Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);
            await _utenteRepository.UpdateAsync(utente);
            return utenteDettaglioDto;
        }


        public async Task DeleteAsync(int id)
        {
            await _utenteRepository.DeleteAsync(id);
        }


    }
}