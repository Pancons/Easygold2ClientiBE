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

namespace EasyGold.API.Services.Implementations
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

        public async Task<bool> UsernameExist(UtenteDTO utenteDettaglioDto)
        {
            bool result = false;
            if (utenteDettaglioDto != null)
                result = await _utenteRepository.UsernameExist(utenteDettaglioDto.Ute_NomeUtente);
            return result;
        }

        public async Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);

            // In fase di inserimento di un nuovo utente, la password viene inizializzata con "password"
            // e criptata
            utente.Ute_Password = CryptPassword("password");

            await _utenteRepository.AddAsync(utente);
            return await GetUserByIdAsync(utente.Ute_IDUtente);
        }


        public async Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = await _utenteRepository.GetUserByIdAsync((int)utenteDettaglioDto.Ute_IDUtente);
            utente = _mapper.Map(utenteDettaglioDto, utente);
            await _utenteRepository.UpdateAsync(utente);
            return await GetUserByIdAsync((int)utenteDettaglioDto.Ute_IDUtente);
        }


        public async Task DeleteAsync(int id)
        {
            await _utenteRepository.DeleteAsync(id);
        }

        public async Task<UtenteDTO> AuthenticateAsync(string username, string password)
        {
            var user = await _utenteRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.Ute_Password))
                return null;

            return _mapper.Map<UtenteDTO>(user);
        }

        public async Task<bool> ChangePassword(PasswordDTO passwordDto)
        {
            bool result = false;

            var utente = await _utenteRepository.GetUserByIdAsync(passwordDto.Ute_IDUtente);
            if (utente != null)
            {
                utente.Ute_Password = CryptPassword(passwordDto.Ute_NewPassword);
                await _utenteRepository.UpdateAsync(utente);

                result = true;
            }
            return result;
        }

        private string CryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

    }
}