using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_causali")]
    public class DbCausali : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Cal_IDAuto { get; set; }

        /// <summary>
        /// Descrizione della Causale.
        /// </summary>
        [StringLength(100)]
        public string Cal_Descrizione { get; set; }

        /// <summary>
        /// Valore del campo abl_IDAuto della tabella dbo.tbco_abilitazioni.
        /// </summary>
        public int Cal_IDDoveUso { get; set; }

        /// <summary>
        /// Valore del campo prc_IDAuto della tabella dbo.tbco_cauProgressivi.
        /// </summary>
        public int Cal_IDProgressivo { get; set; }

        /// <summary>
        /// Valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni. 
        /// Tipo Anagrafica.
        /// </summary>
        public int Cal_IDTipoAnagrafica { get; set; }

        /// <summary>
        /// Valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni. 
        /// Tipo Calcolo IVA.
        /// </summary>
        public int Cal_IDTipoIVA { get; set; }
        
        /// <summary>
        /// Se la causale è annullata.
        /// </summary>
        public bool Cal_Annulla { get; set; }

        // Relazioni
        public virtual ICollection<DbCausaliLang> CausaliLang { get; set; } = new List<DbCausaliLang>();
        //public virtual ICollection<DbCauOrdinamento> Ordinamenti { get; set; } = new List<DbCauOrdinamento>();
    }
}
