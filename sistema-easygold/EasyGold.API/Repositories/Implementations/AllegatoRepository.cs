using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EasyGold.API.Repositories.Implementations
{
    public class AllegatoRepository : IAllegatoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _basePath = "uploads";

        public AllegatoRepository(ApplicationDbContext context)
        {
            _context = context;

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        /// <summary>
        /// Recupera tutti gli allegati dal database.
        /// </summary>
        public async Task<IEnumerable<DbAllegato>> GetAllAsync()
        {
            return await _context.Allegati.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Recupera un allegato per ID.
        /// </summary>
        public async Task<DbAllegato> GetByIdAsync(int id)
        {
            return await _context.Allegati.AsNoTracking().FirstOrDefaultAsync(a => a.All_IDAllegato == id);
        }

        /// <summary>
        /// Aggiunge un nuovo allegato e salva il file su disco.
        /// </summary>
        public async Task AddAsync(DbAllegato allegato)
        {
            if (allegato == null) return;

            allegato.All_ImgUrl = "";
            await _context.Allegati.AddAsync(allegato);
            await _context.SaveChangesAsync();

            // Salva il file se è presente in Base64
            if (!string.IsNullOrEmpty(allegato.All_FileBase64))
            {
                string filePath = await SaveFileAsync(allegato, allegato.All_FileBase64);
                allegato.All_ImgUrl = filePath;
                await UpdateAsync(allegato);
            }
        }

        /// <summary>
        /// Aggiorna un allegato esistente e il relativo file.
        /// </summary>
        public async Task UpdateAsync(DbAllegato allegato)
        {
            var allegatoEsistente = await _context.Allegati.FindAsync(allegato.All_IDAllegato);
            if (allegatoEsistente != null)
            {
                // Se il file è cambiato, elimina il vecchio e salva il nuovo
                if (!string.IsNullOrEmpty(allegato.All_FileBase64))
                {
                    DeleteFile(allegatoEsistente.All_ImgUrl);
                    string filePath = await SaveFileAsync(allegato, allegato.All_FileBase64);
                    allegato.All_ImgUrl = filePath;
                }

                _context.Entry(allegatoEsistente).CurrentValues.SetValues(allegato);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina un allegato e rimuove il file associato.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var allegato = await _context.Allegati.FindAsync(id);
            if (allegato != null)
            {
                DeleteFile(allegato.All_ImgUrl);
                _context.Allegati.Remove(allegato);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Salva il file su disco e restituisce il percorso relativo.
        /// </summary>
        private async Task<string> SaveFileAsync(DbAllegato allegato, string base64Data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(base64Data))
                {
                    Console.WriteLine("❌ ERRORE: La stringa Base64 è nulla o vuota!");
                    return string.Empty;
                }

                // Rimuove il prefisso Base64 se presente (es. data:image/png;base64,)
                if (base64Data.Contains(","))
                {
                    base64Data = base64Data.Split(',')[1];
                }

                byte[] fileBytes;
                try
                {
                    fileBytes = Convert.FromBase64String(base64Data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ ERRORE nella decodifica Base64: {ex.Message}");
                    return string.Empty;
                }

                // Genera la cartella di destinazione
                string folderPath = Path.Combine(_basePath, allegato.All_EntitaRiferimento, allegato.All_RecordId.ToString());
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Se l'estensione non è fornita, assegna ".png" di default
                string estensione = string.IsNullOrWhiteSpace(allegato.All_Estensione) ? Path.GetExtension(allegato.All_NomeFile) : allegato.All_Estensione;

                // Genera il nome del file
                string fileName = $"{allegato.All_IDAllegato}.{estensione}";
                string filePath = Path.Combine(folderPath, fileName);

                // Salva il file
                await File.WriteAllBytesAsync(filePath, fileBytes);

                // Restituisce il percorso accessibile via URL
                return $"/{filePath.Replace("wwwroot", "").Replace("\\", "/").TrimStart('/').Replace(_basePath, "file")}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERRORE GENERALE nel salvataggio del file: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Elimina un file dal disco.
        /// </summary>
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

        /// <summary>
        /// Legge un file dal disco.
        /// </summary>
        public async Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath)
        {
            return ReadFile(filePath);
        }

        private (bool success, byte[] fileBytes, string contentType) ReadFile(string filePath)
        {
            // Normalizza i percorsi
            string rootPath = Path.GetFullPath(_basePath);
            string requestedPath = Path.GetFullPath(Path.Combine(_basePath, filePath));

            // Verifica sicurezza: il file deve essere dentro basePath
            if (!requestedPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
                return (false, null, null);

            if (!System.IO.File.Exists(requestedPath))
                return (false, null, null);

            var fileExt = Path.GetExtension(requestedPath);

            // Opzionale: blocca alcune estensioni
            var blockedExtensions = new[] { ".config", ".cs", ".exe", ".dll", ".json" };
            if (blockedExtensions.Contains(fileExt))
                return (false, null, null);


            // Se passa tutti i controlli, restituisce l'array di byte ed il content type
            return (true, File.ReadAllBytes(requestedPath), GetContentType(requestedPath));
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
                contentType = "application/octet-stream";
            return contentType;
        }
    }
}
