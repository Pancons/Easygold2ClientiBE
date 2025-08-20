using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_impFinanziarie_lang")]
    public class DbImpFinanziarieLang
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        [Key, Column(Order = 0)]
        public int Imfid_ISONum { get; set; }

        /// <summary>
        /// ID dell'impresa finanziaria associata.
        /// </summary>
        [Key, Column(Order = 1)]
        public int Imfid_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta dell'impresa finanziaria.
        /// </summary>
        [StringLength(100)]
        public string Imfid_Descrizione { get; set; }

        [ForeignKey("Imfid_ID")]
        public virtual DbImpFinanziarie ImpFinanziarie { get; set; }
    }
}