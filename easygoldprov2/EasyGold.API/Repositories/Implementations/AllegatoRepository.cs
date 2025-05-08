using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities.Allegati;
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

            // Inserisco il record sul DB per generare l'ID che sarà il nome del file
            allegato.All_ImgUrl = "";
            await _context.Allegati.AddAsync(allegato);
            await _context.SaveChangesAsync();

            // Salva il file se è presente in Base64
            if (!string.IsNullOrEmpty(allegato.All_FileBase64))
            {
                string filePath = await SaveFileAsync(allegato, allegato.All_FileBase64);
                allegato.All_ImgUrl = filePath;
                await _context.SaveChangesAsync();
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
        /// Aggiorna tutti gli allegati di una entità.
        /// </summary>
        public async Task UpdateAllAsync(int idEntita, string tipoEntita, List<DbAllegato> allegati)
        {
            var allegatiEsistenti = await _context.Allegati
                .Where(a => a.All_EntitaRiferimento == tipoEntita && a.All_RecordId == idEntita)
                .ToListAsync();

            // Verifico quali allegati non sono più presenti nella lista nuova lista e li rimuovo definitivamente
            var allegatiRimossi = allegatiEsistenti.Where(a => !allegati.Any(m => (m.All_IDAllegato == a.All_IDAllegato && a.All_IDAllegato > 0))).ToList();
            foreach (var allegato in allegatiRimossi)
            {
                await DeleteAsync(allegato.All_IDAllegato);
            }

            // Per tutti gli allegati per cui mi viene passato All_FileBase64 procedo con l'inserimento o l'aggiornamento
            foreach (var allegato in allegati.Where(all => all.All_FileBase64 != null).ToList())
            {
                var allegatoEsistente = allegatiEsistenti.Where(a => a.All_IDAllegato == allegato.All_IDAllegato).FirstOrDefault();

                if (allegatoEsistente == null)
                {
                    allegato.All_IDAllegato = 0;
                    allegato.All_RecordId = idEntita;
                    await AddAsync(allegato);
                } 
                else
                {
                    await UpdateAsync(allegato);
                }
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
                DeleteFile(allegato.All_ImgUrl.Replace("/file", ""));
                _context.Allegati.Remove(allegato);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Legge un file dal disco.
        /// </summary>
        public async Task<(bool success, byte[] fileBytes, string contentType)> GetFileByPathAsync(string filePath)
        {
            return ReadFile(filePath);
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
                return $"/{filePath.Replace("\\", "/").TrimStart('/').Replace(_basePath, "file")}";
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
            string fullPath = IsValid(filePath);
            if (!string.IsNullOrEmpty(IsValid(fullPath)))
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }

        /// <summary>
        /// Legge un file dal disco.
        /// </summary>
        private (bool success, byte[] fileBytes, string contentType) ReadFile(string filePath)
        {
            string fullPath = IsValid(filePath);
            if (string.IsNullOrEmpty(IsValid(fullPath)))
                return (false, null, null);

            // Se passa tutti i controlli, restituisce l'array di byte ed il content type
            return (true, File.ReadAllBytes(fullPath), GetContentType(fullPath));
        }

        /// <summary>
        /// Verifica che il percorso ed il tipo di file siano corretti
        /// </summary>
        private string IsValid(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return "";

            // Normalizza i percorsi
            string rootPath = Path.GetFullPath(_basePath);
            string requestedPath = Path.GetFullPath(Path.Combine(rootPath, filePath.TrimStart('/')));

            // Verifica sicurezza: il file deve essere dentro basePath
            if (!requestedPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
                return "";

            if (!System.IO.File.Exists(requestedPath))
                return "";

            var fileExt = Path.GetExtension(requestedPath);

            // Opzionale: blocca alcune estensioni
            var blockedExtensions = new[] { ".config", ".cs", ".exe", ".dll", ".json" };
            if (blockedExtensions.Contains(fileExt))
                return "";

            return requestedPath;
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
