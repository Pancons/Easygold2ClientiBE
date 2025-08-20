using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_cauProgressivi")]
    public class DbCauProgressivi
    {
        /// <summary>
        /// ID auto generato per il progressivo.
        /// </summary>
        [Key]
        public int Cpr_IDAuto { get; set; }

        /// <summary>
        /// Descrizione del progressivo.
        /// </summary>
        [StringLength(50)]
        public string Cpr_Descrizione { get; set; }

        /// <summary>
        /// Indica come il saldo giacenza viene modificato.
        /// </summary>
        public int Cpr_CalcGiacenza { get; set; }

        /// <summary>
        /// Indica come la disponibilità viene calcolata.
        /// </summary>
        public int Cpr_CalcDisponibilita { get; set; }

        /// <summary>
        /// Indica se il progressivo è annullato.
        /// </summary>
        public bool Cpr_Annullato { get; set; }

        public virtual ICollection<DbCauProgressiviLang> CauProgressiviLang { get; set; }= new List<DbCauProgressiviLang>();
    }
}