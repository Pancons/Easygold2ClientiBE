using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Brand
{
    [Table("tbcl_brand")]
    public class DbBrand : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Brd_IDAuto { get; set; }

        /// <summary>
        /// Campo Alfa 100 caratteri. È la descrizione del Brand.
        /// </summary>
        [StringLength(100)]
        public string Brd_Brand { get; set; }

        /// <summary>
        /// Campo bit. Se è a True il Brand è annullato.
        /// </summary>
        public bool Brd_Annulla { get; set; }

        public virtual ICollection<DbBrandLang> BrandLang { get; set; } = new List<DbBrandLang>();
        public virtual ICollection<DbBrandCat> BrandCat { get; set; } = new List<DbBrandCat>();
    }
}