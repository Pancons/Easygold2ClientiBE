using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigProgramma
{
    public class DbModuloEasygoldLang
    {
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Mdeid_IDAuto { get; set; }
        public int Mdeid_ISONum { get; set; }
        public int Mdeid_ID { get; set; }
        public string Mdeid_Descrizione { get; set; }
        public string Mdeid_DescEstesa { get; set; }
    }
}
