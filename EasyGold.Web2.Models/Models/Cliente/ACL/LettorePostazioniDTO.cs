using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class LettorePostazioniDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Lpo_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID della Postazione.")]
        public int Lpo_IDPostazione { get; set; }

        [SwaggerSchema(Description = "IP del Lettore di Card.")]
        [StringLength(50)]
        public string Lpo_IDLettore { get; set; }

        [SwaggerSchema(Description = "Nome dispositivo del Lettore di Card.")]
        [StringLength(50)]
        public string Lpo_DevLettore { get; set; }

        [SwaggerSchema(Description = "Indica se il record è annullato.")]
        public bool Lpo_Annullato { get; set; }
    }
}