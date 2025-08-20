using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto
{
    [Table("tbcl_categorie")]
    public class DbCategorie : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Cat_IDAuto { get; set; }

        /// <summary>
        /// ID della Categoria superiore.
        /// </summary>
        public int? Cat_IDPadre { get; set; }

        /// <summary>
        /// Descrizione della Categoria.
        /// </summary>
        [StringLength(100)]
        public string Cat_DescCategoria { get; set; }

        /// <summary>
        /// Se la Categoria è annullata.
        /// </summary>
        public bool Cat_Annulla { get; set; }

        // Relazioni
        public virtual ICollection<DbCategorieLang> CategorieLang { get; set; } = new List<DbCategorieLang>();
        public virtual ICollection<DbConfigCategorie> Configurazioni { get; set; } = new List<DbConfigCategorie>();
    }
}