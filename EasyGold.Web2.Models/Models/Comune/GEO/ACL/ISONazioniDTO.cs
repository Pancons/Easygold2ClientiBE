using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    public class ISONazioniDTO
    {
        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione.")]
        public int Ntn_ISO1 { get; set; }

        [SwaggerSchema(Description = "Nome della Nazione.")]
        [StringLength(200)]
        public string Ntn_Descrizione { get; set; }

        [SwaggerSchema(Description = "Sigla ISO 3166-1 Alfa-2 della Nazione.")]
        [StringLength(2)]
        public string Ntn_ISO1A2 { get; set; }

        [SwaggerSchema(Description = "Sigla ISO 3166-1 Alfa-3 della Nazione.")]
        [StringLength(3)]
        public string Ntn_ISO1A3 { get; set; }

        [SwaggerSchema(Description = "Prefisso telefonico internazionale della Nazione.")]
        [StringLength(10)]
        public string Ntn_PrefTelef { get; set; }

        [SwaggerSchema(Description = "ID della tabella 'Continenti'.")]
        public int Ntn_Continente { get; set; }

        [SwaggerSchema(Description = "ID della tabella 'Continenti'.")]
        public int Ntn_ContinenteLegale { get; set; }

        [SwaggerSchema(Description = "ISO 3166 1 della Nazione a cui appartiene il territorio.")]
        public int Ntn_Appartiene { get; set; }

        [SwaggerSchema(Description = "Capitale De Iure della Nazione.")]
        [StringLength(100)]
        public string Ntn_Capitale { get; set; }

        [SwaggerSchema(Description = "Capitale De Facto della Nazione.")]
        [StringLength(100)]
        public string Ntn_CapitaleDeFacto { get; set; }

        [SwaggerSchema(Description = "Capitale Amministrativa della Nazione.")]
        [StringLength(100)]
        public string Ntn_CapitaleAmm { get; set; }

        [SwaggerSchema(Description = "Capitale nella lingua originale della Nazione.")]
        [StringLength(100)]
        public string Ntn_CapitaleIdioma { get; set; }

        [SwaggerSchema(Description = "Codice della valuta.")]
        public int Ntn_IDValuta { get; set; }

        [SwaggerSchema(Description = "Lunghezza del CAP della Nazione.")]
        public int Ntn_LunghezzaCAP { get; set; }

        [SwaggerSchema(Description = "Nome della Partita IVA della Nazione.")]
        [StringLength(50)]
        public string Ntn_NomePI { get; set; }

        [SwaggerSchema(Description = "Tipo di Partita IVA della Nazione.")]
        public int Ntn_TipoPI { get; set; }

        [SwaggerSchema(Description = "Lunghezza del campo Partita IVA.")]
        public int Ntn_LunghezzaPI { get; set; }

        [SwaggerSchema(Description = "Nome del Codice Fiscale nella Nazione.")]
        [StringLength(50)]
        public string Ntn_NomeCF { get; set; }

        [SwaggerSchema(Description = "Tipo del Codice Fiscale della Nazione.")]
        public int Ntn_TipoCF { get; set; }

        [SwaggerSchema(Description = "Lunghezza del Codice Fiscale.")]
        public int Ntn_LunghezzaCF { get; set; }

        [SwaggerSchema(Description = "Descrizione campo per lo Stato/Regione.")]
        [StringLength(100)]
        public string Ntn_DescStatoRegione { get; set; }

        [SwaggerSchema(Description = "Indicatore per Stati/Regioni presenti.")]
        public bool Ntn_StatoRegione { get; set; }

        [SwaggerSchema(Description = "Lunghezza del campo Sigla Provincia.")]
        public int Ntn_LungSiglaProv { get; set; }

        [SwaggerSchema(Description = "Indicatore presenza Province.")]
        public bool Ntn_ProvSiNo { get; set; }

        [SwaggerSchema(Description = "Indicatore presenza provincie nella tabella.")]
        public bool Ntn_Province { get; set; }

        [SwaggerSchema(Description = "Indicatore presenza Località nella tabella.")]
        public bool Ntn_Localita { get; set; }

        [SwaggerSchema(Description = "Indicatore presenza Indirizzi nella tabella.")]
        public bool Ntn_Indirizzi { get; set; }
    }
}