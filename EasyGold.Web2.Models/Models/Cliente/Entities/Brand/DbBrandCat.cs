using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Brand
{
    [Table("tbcl_brandCat")]
    public class DbBrandCat : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Brc_IDAuto { get; set; }

        /// <summary>
        /// ID del brand associato.
        /// </summary>
        public int Brc_IDBrand { get; set; }

        /// <summary>
        /// ID della categoria associata.
        /// </summary>
        public int Brc_IDCategoria { get; set; }

        /// <summary>
        /// Campo bit. Se è True la Categoria è annullata.
        /// </summary>
        public bool Brc_Annullato { get; set; }

        [ForeignKey("Brc_IDBrand")]
        public virtual DbBrand Brand { get; set; }
    }
}