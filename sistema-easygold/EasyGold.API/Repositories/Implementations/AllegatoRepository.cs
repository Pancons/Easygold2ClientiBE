using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Repositories.Interfaces;
using AutoMapper;

namespace EasyGold.API.Repositories
{
    public class AllegatoRepository : IAllegatoRepository
    {
        private readonly List<DbAllegato> _allegati = new List<DbAllegato>();
        private readonly IMapper _mapper;
        private readonly string _basePath = "wwwroot/uploads";

        public AllegatoRepository(IMapper mapper)
        {
            _mapper = mapper;
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task<IEnumerable<DbAllegato>> GetAllAsync()
        {
            return await Task.FromResult(_allegati);
        }

        public async Task<DbAllegato> GetByIdAsync(int id)
        {
            return await Task.FromResult(_allegati.FirstOrDefault(a => a.All_IDAllegato == id));
        }

        public async Task AddAsync(DbAllegato allegato_)
        {
            var allegato = _mapper.Map<DbAllegato>(allegato_);

            // Se il file viene caricato in Base64, salvalo e imposta l'URL
            if (!string.IsNullOrEmpty(allegato.All_FileBase64))
            {
                string filePath = await SaveFileAsync(allegato_, allegato_.All_FileBase64);
                allegato_.SetImgUrl(filePath);
            }

            _allegati.Add(allegato_);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(DbAllegato allegato_)
        {
            var existing = await GetByIdAsync(allegato_.All_IDAllegato);
            if (existing != null)
            {
                // Se il file viene aggiornato, rimuoviamo il vecchio e salviamo il nuovo
                if (!string.IsNullOrEmpty(allegato_.All_FileBase64))
                {
                    DeleteFile(existing.All_ImgUrl);
                    string filePath = await SaveFileAsync(existing, allegato_.All_FileBase64);
                    allegato_.SetImgUrl(filePath);
                }
                
                _allegati.Remove(existing);
                _allegati.Add(_mapper.Map<DbAllegato>(allegato_));
            }
        }

        public async Task DeleteAsync(int id)
        {
            var allegato = await GetByIdAsync(id);
            if (allegato != null)
            {
                DeleteFile(allegato.All_ImgUrl);
                _allegati.Remove(allegato);
            }
        }

        private async Task<string> SaveFileAsync(DbAllegato allegato, string base64Data)
        {
            try
            {
                string folderPath = Path.Combine(_basePath, allegato.All_EntitaRiferimento, allegato.All_RecordId.ToString());
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = $"{allegato.All_NomeFile}{allegato.All_Estensione}";
                string filePath = Path.Combine(folderPath, fileName);

                byte[] fileBytes = Convert.FromBase64String(base64Data);
                await File.WriteAllBytesAsync(filePath, fileBytes);
                
                return $"/{filePath.Replace("wwwroot", "").Replace("\\", "/").TrimStart('/') }";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nel salvataggio del file: {ex.Message}");
                return string.Empty;
            }
        }

        private void DeleteFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string fullPath = Path.Combine("wwwroot", filePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
    }
}