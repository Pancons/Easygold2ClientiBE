using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_province_lang")]
    public class DbProvinceLang
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        [Key, Column(Order = 0)]
        public int Strid_ISONum { get; set; }

        /// <summary>
        /// ID della Provincia associata.
        /// </summary>
        [Key, Column(Order = 1)]
        public int Strid_ID { get; set; }

        /// <summary>
        /// Nome tradotto della Provincia.
        /// </summary>
        [StringLength(200)]
        public string Strid_Descrizione { get; set; }

        [ForeignKey("Strid_ID")]
        public virtual DbProvince Province { get; set; }
    }
}