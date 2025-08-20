using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tagProdotti_lang")]
    public class DbTagProdottiLang
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        [Key, Column(Order = 0)]
        public int EtpId_ISONum { get; set; }

        /// <summary>
        /// ID dell’etichetta del prodotto associato.
        /// </summary>
        [Key, Column(Order = 1)]
        public int EtpId_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta dell’etichetta.
        /// </summary>
        [StringLength(100)]
        public string EtpId_Descrizione { get; set; }

        [ForeignKey("EtpId_ID")]
        public virtual DbTagProdotti TagProdotti { get; set; }
    }
}