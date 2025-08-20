using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    public class IdStatoRegioniDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Strid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record principale tradotto.")]
        public int Strid_ID { get; set; }

        [SwaggerSchema(Description = "Nome tradotto dello Stato/Nazione, fino a 200 caratteri.")]
        [StringLength(200)]
        public string Strid_Descrizione { get; set; }
    }
}