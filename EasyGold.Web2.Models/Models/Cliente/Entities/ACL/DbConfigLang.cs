using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("syscl_config_lag")]
    public class DbConfigLang
    {
        [Key, Column(Order = 0)]
        public int Sysid_ISONum { get; set; }

      
        public int Sysid_ID { get; set; }

        [StringLength(100)]
        public string Sysid_NomeCampo { get; set; }

        [ForeignKey("Sysid_ID")]
        public virtual DbConfig Config { get; set; }
    }
}