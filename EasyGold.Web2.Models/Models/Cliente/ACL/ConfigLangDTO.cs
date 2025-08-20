using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ConfigLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua associata.")]
        public int Sysid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID di riferimento di configurazione.")]
        public int Sysid_ID { get; set; }

        [SwaggerSchema(Description = "Nome campo tradotto nella lingua specifica.")]
        [StringLength(100)]
        public string Sysid_NomeCampo { get; set; }
    }
}