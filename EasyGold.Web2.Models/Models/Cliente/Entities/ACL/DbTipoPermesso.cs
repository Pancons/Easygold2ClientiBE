using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbco_tipoPermesso")]//
    public class DbTipoPermesso : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Tpa_IDAuto { get; set; }
        /// <summary>
        /// è la descrizione del permesso
        /// </summary>
        [StringLength(50)]
        public string Tpa_TipoPermesso { get; set; }

        /// <summary>
        /// È il livello del permesso può assumere 4 valori
        /// </summary>
        public int? Tpa_LivelloPermesso { get; set; }

        public virtual ICollection<DbPermessiGruppo> PermessiGruppo { get; set; } = new List<DbPermessiGruppo>();
    }
}