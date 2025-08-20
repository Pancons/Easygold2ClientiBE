
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    public class DbModuloEasygoldLang : BaseDbEntity
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
