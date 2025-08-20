using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    public class IdISONazioniDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Ntnid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record principale tradotto.")]
        public int Ntnid_ID { get; set; }

        [SwaggerSchema(Description = "Nome tradotto della Nazione.")]
        [StringLength(100)]
        public string Ntnid_Nazione { get; set; }

        [SwaggerSchema(Description = "Capitale De Iure tradotta.")]
        [StringLength(100)]
        public string Ntnid_Capitale { get; set; }

        [SwaggerSchema(Description = "Capitale De Facto tradotta.")]
        [StringLength(100)]
        public string Ntn_CapitaleDeFacto { get; set; }

        [SwaggerSchema(Description = "Capitale Amministrativa tradotta.")]
        [StringLength(100)]
        public string Ntn_CapitaleAmm { get; set; }
    }
}