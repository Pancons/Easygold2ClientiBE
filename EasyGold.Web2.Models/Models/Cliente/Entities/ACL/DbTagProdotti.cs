using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tagProdotti")]
    public class DbTagProdotti : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Etp_IDAuto { get; set; }

        /// <summary>
        /// Descrizione dell’Etichetta del Prodotto.
        /// </summary>
        [StringLength(100)]
        public string Etp_Descrizione { get; set; }

        /// <summary>
        /// ID del gruppo dell'etichetta.
        /// </summary>
        public int Etp_Gruppo { get; set; }

        /// <summary>
        /// Colore della scritta dell’etichetta.
        /// </summary>
        [StringLength(16)]
        public string Etp_ColEtichetta { get; set; }

        /// <summary>
        /// Colore dello sfondo dell’etichetta.
        /// </summary>
        [StringLength(16)]
        public string Etp_ColSfondo { get; set; }

        /// <summary>
        /// ID del tipo di etichetta.
        /// </summary>
        public int Etp_TipoEtichetta { get; set; }

        /// <summary>
        /// Data di scadenza dell’etichetta.
        /// </summary>
        public DateTime? Etp_DataScadenza { get; set; }

        /// <summary>
        /// Indica se l’etichetta è in evidenza.
        /// </summary>
        public bool Etp_InEvidenza { get; set; }

        /// <summary>
        /// Indica se l’etichetta è annullata.
        /// </summary>
        public bool Etp_Annullato { get; set; }

        public virtual ICollection<DbTagProdottiLang> Traduzioni { get; set; } = new List<DbTagProdottiLang>();
    }
}