using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigProgramma
{
    public class DbModuloEasygold
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

    }
}
