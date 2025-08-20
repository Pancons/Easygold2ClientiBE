using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    public class DbModuloEasygold : BaseDbEntity
    {
        [Key]
        public int Mde_IDAuto { get; set; }

        /// <summary>
        /// Nome modulo su e-commerce
        /// </summary>
        [StringLength(50)]
        public string Mde_CodEcomm { get; set; }
        /// <summary>
        /// Descrizione del modulo
        /// </summary>
        [StringLength(50)]
        public string Mde_Descrizione { get; set; }

        /// <summary>
        /// Descrizione estesa del modulo
        /// </summary>
        [StringLength(400)]
        public string Mde_DescrizioneEstesa { get; set; }

        // Relazione con DbModuloCliente
        public ICollection<DbModuloCliente> ModuliClienti { get; set; }
    }
}
