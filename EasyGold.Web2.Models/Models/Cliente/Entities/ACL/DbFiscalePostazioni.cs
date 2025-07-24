using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_fiscalePostazioni
    /// Per la Postazione che ha accesso ad un Registratore Fiscale si inseriscono i dati per gestirlo.
    /// </summary>
    [Table("tbcl_fiscalePostazioni")]
    public class DbFiscalePostazioni
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Fpo_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo tpo_IDAuto della tabella dbo.tbcl_testataPostazioni.
        /// Nella Form è un campo Combo a Scelta Singola con ricerca della tabella dbo.tbcl_testataPostazioni.
        /// </summary>
        public int Fpo_IDPostazione { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo rfi_IDAuto della tabella dbo.tbcl_regFiscale.
        /// Nella Form è un campo Combo a Scelta Singola con ricerca della tabella dbo.tbcl_regFiscale.
        /// </summary>
        public int Fpo_IDRegFiscale { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// È l’indirizzo IP di dove deve essere scritto lo scontrino.
        /// </summary>
        [StringLength(50)]
        public string Fpo_IPPath { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True il Registratore Fiscale è installato.
        /// </summary>
        public bool Fpo_Attivo { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True il record non è attivo.
        /// </summary>
        public bool Fpo_Annullato { get; set; }

        /// <summary>
        /// Chiave esterna verso la tabella delle Testate Postazioni.
        /// </summary>
        [ForeignKey("Fpo_IDPostazione")]
        public virtual DbTestataPostazioni TestataPostazioni { get; set; }

        /// <summary>
        /// Chiave esterna verso la tabella dei Registratori Fiscali.
        /// </summary>
        [ForeignKey("Fpo_IDRegFiscale")]
        public virtual DbRegFiscale RegFiscale { get; set; }
    }
}
