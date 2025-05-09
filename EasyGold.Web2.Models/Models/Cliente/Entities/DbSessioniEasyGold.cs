using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_SessioniEasyGold")]
    public class DbSessioniEasyGold : BaseDbEntity
    {
        /// <summary>
        /// Campo numerico auto
        /// </summary>
        [Key]
        public int Sse_IDAuto { get; set; }

        /// <summary>
        /// È il codice Cliente con cui l’Utente sta facendo il Login.
        /// </summary>
        public int Sse_IDCliente { get; set; }

        /// <summary>
        /// È il codice dell’Utente che ha fatto il Login.
        /// </summary>
        public int Sse_IDUtente { get; set; }

        /// <summary>
        /// È la Data e l’Ora della Login.
        /// </summary>
        public DateTime? Sse_DataLogin { get; set; }

        /// <summary>
        /// Se a True la sessione è terminata.
        /// </summary>
        public bool? Sse_SesScaduta { get; set; }

        /// <summary>
        ///  È la Data e l’Ora del Logout da Easygold.
        /// </summary>
        public DateTime? Sse_DataLogout { get; set; }
        /// <summary>
        /// Se a True la sessione è terminata in automatico ma non dall’Utente.
        /// </summary>
        public bool? Sse_sesForzata { get; set; }

        /// <summary>
        /// È la Data e l’Ora del Logout forzato.
        /// </summary>
        public DateTime? Sse_DataLogoutForzato { get; set; }
    }
}