using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    public class DbAllegato
    {
        /// <summary>
        /// ID dell'allegato.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int All_IDAllegato { get; set; }

        /// <summary>
        /// Nome del file allegato.
        /// </summary>
        public string All_NomeFile { get; set; }

        /// <summary>
        /// Estensione del file allegato.
        /// </summary>
        public string All_Estensione { get; set; }

        /// <summary>
        /// Dimensione del file allegato in byte.
        /// </summary>
        public int All_Dimensione { get; set; }

        /// <summary>
        /// Entità di riferimento per l'allegato.
        /// </summary>
        public string All_EntitaRiferimento { get; set; }

        /// <summary>
        /// ID del record a cui l'allegato è associato.
        /// </summary>
        public int All_RecordId { get; set; }

        /// <summary>
        /// Note aggiuntive sull'allegato.
        /// </summary>
        public string? All_Note { get; set; }

        /// <summary>
        /// URL dell'immagine allegata (solo lettura).
        /// </summary>
        public string All_ImgUrl { get; set; }

        /// <summary>
        /// Base64 del file allegato (non salvato nel database).
        /// </summary>
        [NotMapped]
        public string All_FileBase64 { get; set; }

        /// <summary>
        /// Imposta l'URL dell'immagine allegata (solo internamente nel codice).
        /// </summary>
        public void SetImgUrl(string url)
        {
            All_ImgUrl = url;
        }
    }
}
