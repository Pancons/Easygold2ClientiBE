using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models;
using EasyGold.API.Models.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Services
{
    public class UtenteService
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IMapper _mapper;

        public UtenteService(IUtenteRepository utenteRepository, IMapper mapper)
        {
            _utenteRepository = utenteRepository;
            _mapper = mapper;
        }

        /*
        public async Task<IEnumerable<UtenteDTO>> GetAllAsync()
        {
            var utenti = await _utenteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UtenteDTO>>(utenti);
        }

        public async Task<UtenteDettaglioDTO> GetByIdAsync(int id)
        {
            var utente = await _utenteRepository.GetByIdAsync(id);
            return _mapper.Map<UtenteDettaglioDTO>(utente);
        }

       

        public async Task UpdateAsync(UtenteDettaglioDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);
            await _utenteRepository.UpdateAsync(utente);
        }

        public async Task DeleteAsync(int id)
        {
            await _utenteRepository.DeleteAsync(id);
        }
        */
        public async Task<(IEnumerable<UtenteDTO> Users, int Total)> GetUsersListAsync(UserFilterDTO filter)
        {
            return await _utenteRepository.GetUsersListAsync(filter);
        }

        public async Task<UtenteDTO> GetUserByIdAsync(int id)
        {
            return await _utenteRepository.GetUserByIdAsync(id);
        }

        public async Task AddAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);
            await _utenteRepository.AddAsync(utente);
        }


        public async Task UpdateAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);
            await _utenteRepository.UpdateAsync(utente);
        }

    }
}