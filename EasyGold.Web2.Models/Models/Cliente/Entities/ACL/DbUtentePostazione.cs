using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_utentePostazioni")]
    public class DbUtentePostazione
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Upo_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo neg_IDAuto della tabella dbo.tbcl_utenteNegozi. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_negozi.
        /// </summary>
        [Required]
        public int Upo_IdUtente_IDNegozio { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo pos_IDAuto della tabella dbo.tbcl_postazioni. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_postazioni.
        /// </summary>
        [Required]
        public int Upo_IDPostazione { get; set; }

        /// <summary>
        /// Campo Bit. Se a True l’Utente NON ha più accesso al Negozio.
        /// </summary>
        [Required]
        public bool Upo_Annullato { get; set; }

        /*[StringLength(100)]
        public string Post_Descrizione { get; set; }*/

        // Eventuali relazioni future possono essere aggiunte qui

        // Relazione con i negozi
        
      
        [ForeignKey("Upo_IDUtente")]
        public virtual DbUtente Utente { get; set; }

        [ForeignKey("Upo_IDNegozio")]
        public virtual DbNegozi Negozio { get; set; }

        [ForeignKey("Upo_IDPostazione")]
        public virtual DbTestataPostazioni Postazione { get; set; }


    }
}