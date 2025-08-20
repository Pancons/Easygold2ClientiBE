using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tipoSKU")]
    public class DbTipoSKU
    {
        /// <summary>
        /// ID Automatico per il tipo di SKU.
        /// </summary>
        [Key]
        public int Sku_IDAuto { get; set; }

        /// <summary>
        /// Tipo di SKU, collegato alla tabella di tabelle comuni.
        /// </summary>
        public int Sku_TipoSKU { get; set; }

        /// <summary>
        /// Valore indicato per la tabella SKU.
        /// </summary>
        [StringLength(20)]
        public string Sku_Valore { get; set; }

        /// <summary>
        /// Indica se il record è annullato.
        /// </summary>
        public bool Sku_Annullato { get; set; }
    }
}