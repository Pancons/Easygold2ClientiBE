using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    public class DbAllegato
    {
        /// <summary>
        /// ID dell'allegato.
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
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
        public string All_Note { get; set; }

        /// <summary>
        /// URL dell'immagine allegata.
        /// </summary>
        public string All_ImgUrl { get; set; }
    }
}
