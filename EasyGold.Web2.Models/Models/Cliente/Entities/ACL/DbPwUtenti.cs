using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_pwUtenti")]//
    public class DbPwUtenti : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto
        /// </summary>
        [Key]
        public int Utp_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero
        /// </summary>
        public int Utp_IDUtente { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo tpp_IDAuto della tabella dbo.tbco_tipoPw. Nella Form è un campo Combo a Scelta Singola della tabella dbo.tbco_tipoPw.
        /// </summary>
        public int Utp_TipoPw { get; set; }

        /// <summary>
        /// Campo Alfa 100 numeri. è La password dell'utente
        /// </summary>
        [StringLength(100)]
        public string Utp_PwUtente { get; set; }

        public virtual DbUtente Utente { get; set; } = new DbUtente();
        public virtual DbTipoPw TipoPw  { get; set; } = new DbTipoPw();



    }
}