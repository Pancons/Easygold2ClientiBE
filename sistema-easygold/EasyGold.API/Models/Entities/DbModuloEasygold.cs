
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Entities
{
    public class DbModuloEasygold
    {
        [Key]  // <- Definisce la chiave primaria
        public int Mde_IDAuto { get; set; }
        public string Mde_Descrizione { get; set; }
        public string Mde_DescrizioneEstesa { get; set; }
    }
}
