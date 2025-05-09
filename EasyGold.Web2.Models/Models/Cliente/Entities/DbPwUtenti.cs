using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_pwUtenti")]
    public class dbPwUtenti
    {
        /// <summary>
        /// Campo Numerico Intero Auto
        /// </summary>
        [Key]
        public int Utp_IDAuto { get; set; }

        /// <summary>
        /// È il campo ute_IDAuto della tabella dbo.tbcl_utenti.
        /// </summary>
        public int Utp_IDUtente { get; set; }
        /// <summary>
        /// È il campo tpp_IDAuto della tabella dbo.tbco_tipoPw.
        /// </summary>
        public int Utp_TipoPw { get; set; }

        /// <summary>
        /// è La password dell'utente
        /// </summary>
        [StringLength(100)]
        public string Utp_PwUtente {get; set; }
    }
}