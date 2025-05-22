using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("tbcl_tipoPw")]
    public class DbTipoPw : BaseDbEntity
    {
        /// <summary>
        /// Campo numerico auto
        /// </summary>
        [Key]
        public int Tpp_IDAuto { get; set; }

        /// <summary>
        /// È il tipo di password che è inserita nella tabella delle password degli utenti.
        /// </summary>
        [StringLength(50)]
        public string Tpp_TipoPw { get; set; }
    }
}       