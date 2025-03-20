using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Entities
{
    public class DbModuloEasygold
    {
        [Key]
        public int Mde_IDAuto { get; set; }

        /// <summary>
        /// Descrizione del modulo
        /// </summary>
        [StringLength(50)]
        public string Mde_Descrizione { get; set; }

        /// <summary>
        /// Descrizione estesa del modulo
        /// </summary>
        [StringLength(150)]
        public string Mde_DescrizioneEstesa { get; set; }

        // Relazione con DbModuloCliente
        public ICollection<DbModuloCliente> ModuliClienti { get; set; }
    }
}
