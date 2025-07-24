using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class StampePostazioniDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Tpo_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID della Postazione.")]
        public int Tpo_IDPostazione { get; set; }

        [SwaggerSchema(Description = "ID del Modulo di Stampa.")]
        public int Tpo_IDStampa { get; set; }

        [SwaggerSchema(Description = "IP del Device di Stampa.")]
        [StringLength(50)]
        public string Tpo_IPDevice { get; set; }

        [SwaggerSchema(Description = "Nome del Device di Stampa.")]
        [StringLength(100)]
        public string Tpo_Device { get; set; }

        [SwaggerSchema(Description = "Indica se la stampa è diretta.")]
        public bool Tpo_Diretta { get; set; }

        [SwaggerSchema(Description = "Indica se il record è annullato.")]
        public bool Tpo_Annullato { get; set; }
    }
}