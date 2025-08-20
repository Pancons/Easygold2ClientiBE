using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Brand
{
    [Table("tbcl_brand_lang")]
    public class DbBrandLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int BrdId_ISONum { get; set; }

        /// <summary>
        /// ID del brand principale
        /// </summary>
        public int BrdId_ID { get; set; }

        /// <summary>
        /// Descrizione del Brand tradotto.
        /// </summary>
        [StringLength(100)]
        public string BrdId_Brand { get; set; }

        [ForeignKey("BrdId_ID")]
        public virtual DbBrand Brand { get; set; }
    }
}