using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class FunzionilangDTO
    {
        [SwaggerSchema(Description = "È il valore del campo abl_IDAuto della tabella principale di cui è stata fatta la traduzione.")]
        public int Ablid_ID { get; set; }

        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? Ablid_ISONum { get; set; }

        [SwaggerSchema(Description = "È la descrizione dell’abilitazione tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(50)]
        public string Ablid_DescFunzione { get; set; }

        [SwaggerSchema(Description = "È la descrizione dell’abilitazione estesa tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(150)]
        public string Ablid_descFunzioneEstesa { get; set; }
    }
}
