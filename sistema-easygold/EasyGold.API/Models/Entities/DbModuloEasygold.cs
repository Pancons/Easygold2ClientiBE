using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Entities
{
    public class DbModuloEasygold
    {
        [Key]
        public int Mde_IDAuto { get; set; }
        public string Mde_Descrizione { get; set; }
        public string Mde_DescrizioneEstesa { get; set; }

        // Relazione con DbModuloCliente
        public ICollection<DbModuloCliente> ModuliClienti { get; set; }
    }
}
