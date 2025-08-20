using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ConfigDTO
    {
        [SwaggerSchema(Description = "ID automatico della configurazione.")]
        public int Sys_IDAuto { get; set; }

        [SwaggerSchema(Description = "Sezione Configurazione.")]
        public int Sys_Sezione { get; set; }
        
        [SwaggerSchema(Description = "Codice nazione associato.")]
        public int Sys_Nazione { get; set; }

        [SwaggerSchema(Description = "Nome del campo di configurazione.")]
        [StringLength(100)]
        public string Sys_NomeCampo { get; set; }

        [SwaggerSchema(Description = "Tipo di cubo dei dati.")]
        public int Sys_TipoCampo { get; set; }

        [SwaggerSchema(Description = "Valore di configurazione specifico.")]
        public string Sys_Valore { get; set; }

        [SwaggerSchema(Description = "Lunghezza del campo se alfanumerico.")]
        public int Sys_Lunghezza { get; set; }
    }
}