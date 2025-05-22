using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.Prodotti
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
        /// È l’IDAuto della stessa tabella dbo.tbcl_categorie della Categoria del livello subito superiore se ci troviamo ad un livello più basso. 
        /// </summary>
        public int Cat_IDPadre { get; set; }
        /// <summary>
        /// È la descrizione della Categoria.
        /// </summary>
        [StringLength(200)]
        public string Cat_DescCategoria { get; set; }
        /// <summary>
        /// Se è a True la Categoria è annullata. 
        /// </summary>
        public bool? Cat_Annulla { get; set; }
    }
}