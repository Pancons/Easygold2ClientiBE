using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto
{
    [Table("tbcl_categorie_lang")]
    public class DbCategorieLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int Catid_ISONum { get; set; }
        
        /// <summary>
        /// ID della Categoria a cui è associata la traduzione.
        /// </summary>
        public int Catid_ID { get; set; }
        
        /// <summary>
        /// Descrizione tradotta della Categoria.
        /// </summary>
        [StringLength(100)]
        public string Catid_DescCategoria { get; set; }

        /// <summary>
        /// Riferimento all'entità Categorie.
        /// </summary>
        [ForeignKey("Catid_ID")]
        public virtual DbCategorie Categoria { get; set; }
    }
}