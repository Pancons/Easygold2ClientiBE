using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_causali")]
    public class DbCausaliComune : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Cac_IDAuto { get; set; }

        /// <summary>
        /// Descrizione della Causale.
        /// </summary>
        [StringLength(100)]
        public string Cac_Descrizione { get; set; }

        /// <summary>
        /// Valore del campo abl_IDAuto della tabella dbo.tbco_abilitazioni.
        /// </summary>
        public int Cac_IDDoveUso { get; set; }

        /// <summary>
        /// Valore del campo prc_IDAuto della tabella dbo.tbco_cauProgressivi.
        /// </summary>
        public int Cac_IDProgressivo { get; set; }

        /// <summary>
        /// Valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni. 
        /// Tipo Anagrafica.
        /// </summary>
        public int Cac_IDTipoAnagrafica { get; set; }

        /// <summary>
        /// Valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni. 
        /// Tipo Calcolo IVA.
        /// </summary>
        public int Cac_IDTipoIVA { get; set; }
        
        /// <summary>
        /// Se la causale è annullata.
        /// </summary>
        public bool Cac_Annulla { get; set; }

        // Relazioni
        public virtual ICollection<DbCausaliComuneLang> CausaliComuneLang { get; set; } = new List<DbCausaliComuneLang>();
        public virtual ICollection<DbCauOrdinamento> Ordinamenti { get; set; } = new List<DbCauOrdinamento>();
    }
}
