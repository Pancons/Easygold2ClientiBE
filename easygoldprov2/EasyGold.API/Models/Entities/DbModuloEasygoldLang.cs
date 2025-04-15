
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    public class DbModuloEasygoldLang
    {
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Mdeid_ISONum { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mdeid_ID { get; set; }
        public string Mdeid_Descrizione { get; set; }
        public string Mdeid_DescEstesa { get; set; }
    }
}
