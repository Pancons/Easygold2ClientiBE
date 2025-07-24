using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class FiscalePostazioniDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Fpo_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID della Postazione.")]
        public int Fpo_IDPostazione { get; set; }

        [SwaggerSchema(Description = "ID del Registratore Fiscale.")]
        public int Fpo_IDRegFiscale { get; set; }

        [SwaggerSchema(Description = "IP Path per lo scontrino.")]
        [StringLength(50)]
        public string Fpo_IPPath { get; set; }

        [SwaggerSchema(Description = "Indica se il registratore fiscale è attivo.")]
        public bool Fpo_Attivo { get; set; }

        [SwaggerSchema(Description = "Indica se il record è annullato.")]
        public bool Fpo_Annullato { get; set; }
    }
}