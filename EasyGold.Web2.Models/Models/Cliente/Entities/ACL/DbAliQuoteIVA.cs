using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_aliquoteIVA")]
    public class DbAliQuoteIVA
    {
        /// <summary>
        /// Campo Numerico Intero Auto per l'aliquota IVA.
        /// </summary>
        [Key]
        public int Iva_IDAuto { get; set; }

        /// <summary>
        /// Descrizione dell’aliquota IVA.
        /// </summary>
        [StringLength(100)]
        public string Iva_Descrizione { get; set; }

        /// <summary>
        /// Aliquota IVA da applicare ai movimenti.
        /// </summary>
        public decimal Iva_Aliquota { get; set; }

        /// <summary>
        /// Se l’aliquota è esente IVA.
        /// </summary>
        public bool Iva_Esenzione { get; set; }

        /// <summary>
        /// Se l’aliquota è scorporata.
        /// </summary>
        public bool Iva_Scorporata { get; set; }

        /// <summary>
        /// Se è stata annullata.
        /// </summary>
        public bool Iva_Annullato { get; set; }

        /// <summary>
        /// Se l’aliquota IVA è stata assolta in uno stato estero.
        /// </summary>
        public bool Iva_Estero { get; set; }

        /// <summary>
        /// Natura IVA per Fattura Elettronica.
        /// </summary>
        public int Iva_NaturaFE { get; set; }

        /// <summary>
        /// Natura IVA per Scontrino.
        /// </summary>
        public int Iva_NaturaSC { get; set; }

        /// <summary>
        /// Lista delle traduzioni associate all’aliquota IVA.
        /// </summary>
        public virtual ICollection<DbAliQuoteIVALang> AliQuoteIVALang { get; set; } = new List<DbAliQuoteIVALang>();
    }
}