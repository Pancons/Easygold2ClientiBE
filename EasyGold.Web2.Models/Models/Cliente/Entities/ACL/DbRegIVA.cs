using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{      
    [Table("syscl_regIVA")]// 
    public class DbRegIVA
    {
        /// <summary>
        /// Codice del registro IVA.
        /// </summary>
        [Key]
        public int RowIdAuto { get; set; }

        /// <summary>
        /// Descrizione del registro IVA.
        /// </summary>
        [StringLength(50)]
        public string RgiDescrizione { get; set; }

        /// <summary>
        /// Prefisso aggiunto prima del numero della fattura.
        /// </summary>
        [StringLength(10)]
        public string RgiPrefisso { get; set; }

        /// <summary>
        /// Suffisso aggiunto dopo il numero della fattura.
        /// </summary>
        [StringLength(10)]
        public string RgiSuffisso { get; set; }

        /// <summary>
        /// Indica se il registro IVA è annullato.
        /// </summary>
        public bool RgiAnnulla { get; set; }

        /// <summary>
        /// Lista dei numeri del registro IVA associati.
        /// </summary>
        public ICollection<DbNumeriRegIVA> NumeriRegIVA { get; set; } = new List<DbNumeriRegIVA>();
    }
}