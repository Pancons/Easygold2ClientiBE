using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("syscl_config")]
    public class DbConfig
    {
        [Key]
        public int Sys_IDAuto { get; set; }

        public int Sys_Sezione { get; set; }
        public int Sys_Nazione { get; set; }

        [StringLength(100)]
        public string Sys_NomeCampo { get; set; }

        public int Sys_TipoCampo { get; set; }
        public string Sys_Valore { get; set; }
        public int Sys_Lunghezza { get; set; }

        public virtual ICollection<DbConfigLang> ConfigLang { get; set; } = new List<DbConfigLang>();
    }
}