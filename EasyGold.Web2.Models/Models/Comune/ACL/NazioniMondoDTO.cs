using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class NazioniMondoDTO
    {
        [SwaggerSchema(Description = "ID Automatico della nazione.")]
        public int Nzm_IDAuto { get; set; }

        [SwaggerSchema(Description = "Nome della nazione.")]
        [StringLength(100)]
        public string Nzm_Nazione { get; set; }

        [SwaggerSchema(Description = "Codice ISO alfa-2 della nazione.")]
        [StringLength(2)]
        public string Nzm_ISOAlfa2 { get; set; }

        [SwaggerSchema(Description = "Codice ISO alfa-3 della nazione.")]
        [StringLength(3)]
        public string Nzm_ISOAlfa3 { get; set; }

        [SwaggerSchema(Description = "Codice ISO numerico della nazione.")]
        public int Nzm_ISONum { get; set; }

        [SwaggerSchema(Description = "Prefisso telefonico della nazione.")]
        [StringLength(10)]
        public string Nzm_PrefTelefonico { get; set; }

        [SwaggerSchema(Description = "Capitale legale della nazione.")]
        [StringLength(100)]
        public string Nzm_CapitaleIure { get; set; }

        [SwaggerSchema(Description = "Capitale di fatto della nazione.")]
        [StringLength(100)]
        public string Nzm_CapitaleFatto { get; set; }

        [SwaggerSchema(Description = "Capitale amministrativa della nazione.")]
        [StringLength(100)]
        public string Nzm_CapitaleAmm { get; set; }

        [SwaggerSchema(Description = "Nome della capitale nella lingua locale.")]
        [StringLength(200)]
        public string Nzm_CapitaleIdioma { get; set; }

        [SwaggerSchema(Description = "Lingue associate alla nazione.")]
        public List<NazioniMondoLangDTO> NazioniMondoLangs { get; set; } = new List<NazioniMondoLangDTO>();
    }
}