using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class NazioniMondoLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int Nzmid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record della tabella principale.")]
        public int Nzmid_ID { get; set; }

        [SwaggerSchema(Description = "Nome della nazione tradotto.")]
        [StringLength(100)]
        public string Nzmid_Nazione { get; set; }

        [SwaggerSchema(Description = "Capitale legale tradotta.")]
        [StringLength(100)]
        public string Nzmid_CapitaleIure { get; set; }

        [SwaggerSchema(Description = "Capitale di fatto tradotta.")]
        [StringLength(100)]
        public string Nzmid_CapitaleFatto { get; set; }

        [SwaggerSchema(Description = "Capitale amministrativa tradotta.")]
        [StringLength(100)]
        public string Nzmid_CapitaleAmm { get; set; }
    }
}