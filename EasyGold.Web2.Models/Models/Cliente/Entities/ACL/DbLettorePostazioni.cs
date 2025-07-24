using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_lettorePostazioni
    /// Per la Postazione che ha accesso ad un Lettore di Card si inseriscono i dati per gestirlo.
    /// </summary>
    [Table("tbcl_lettorePostazioni")]
    public class DbLettorePostazioni
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Lpo_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo tpo_IDAuto della tabella dbo.tbcl_testataPostazioni.
        /// Nella Form è un campo Combo a Scelta Singola con ricerca della tabella dbo.tbcl_testataPostazioni.
        /// </summary>
        public int Lpo_IDPostazione { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// È l’IP di dove si trova installato il lettore di card.
        /// </summary>
        [StringLength(50)]
        public string Lpo_IDLettore { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// Nella Form è un campo Combo a Scelta Singola che è alimentato da un’API apposita che ritorna il nome del device del lettore di card presente.
        /// </summary>
        [StringLength(50)]
        public string Lpo_DevLettore { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True il record non è attivo.
        /// </summary>
        public bool Lpo_Annullato { get; set; }

        /// <summary>
        /// Chiave esterna verso la tabella delle Testate Postazioni.
        /// </summary>
        [ForeignKey("Lpo_IDPostazione")]
        public virtual DbTestataPostazioni TestataPostazioni { get; set; }
    }
}
