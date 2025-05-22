using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO
{
    public class NazioniDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco della nazione")]
        public int Ntn_ISO1 { get; set; }

        [Required]
        [StringLength(200)]
        [SwaggerSchema(Description = "Nome della nazione")]
        public string Ntn_Descrizione { get; set; }

        [StringLength(2)]
        [SwaggerSchema(Description = "È la sigla ISO 3166-1 Alfa-2 della Nazione.")]
        public string? Ntn_ISO1A2 { get; set; }

        [StringLength(3)]
        [SwaggerSchema(Description = "È la sigla ISO 3166-1 Alfa-3 della Nazione")]
        public string? Ntn_ISO1A3 { get; set; }

        [StringLength(10)]
        [SwaggerSchema(Description = "È il prefisso telefonico internazionale della Nazione. Il prefisso deve avere sempre un carattere “+” come primo carattere da controllare")]
        public string? Ntn_PrefTelef { get; set; }

        [SwaggerSchema(Description = "È l’ID della tabella “Continenti”")]
        public int? Ntn_Continente { get; set; }

        [SwaggerSchema(Description = "È l’ID della tabella “Continenti”")]
        public int? Ntn_ContinenteLegale { get; set; }

        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione a cui appartiene il territorio")]
        public int? Ntn_Appartiene { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "È la Capitale De Iure della Nazione")]
        public string? Ntn_Capitale { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "È la Capitale De Facto della Nazione")]
        public string? Ntn_CapitaleDeFacto { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "È la Capitale Amministrativa della Nazione")]
        public string? Ntn_CapitaleAmm { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "È la Capitale nella lingua originale della Nazione")]
        public string? Ntn_CapitaleIdioma { get; set; }

        [SwaggerSchema(Description = "È il codice della valuta presente nella tabella Valute")]
        public int? Ntn_IDValuta { get; set; }

        [SwaggerSchema(Description = "È la lunghezza del CAP della Nazione")]
        public int? Ntn_LunghezzaCAP { get; set; }

        [StringLength(50)]
        [SwaggerSchema(Description = "È il nome della Partita IVA nella Nazione")]
        public string? Ntn_NomePI { get; set; }

        [SwaggerSchema(Description = "È il valore del Tipo di Partita IVA della Nazione. I valori sono 0=Numerica 1=Alfanumerica")]
        public int? Ntn_TipoPI { get; set; }

        [SwaggerSchema(Description = "È la lunghezza del campo della Partita IVA della Nazione")]
        public int? Ntn_LunghezzaPI { get; set; }

        [StringLength(50)]
        [SwaggerSchema(Description = "È il nome del C. F. nella Nazione")]
        public string? Ntn_NomeCF { get; set; }

        [SwaggerSchema(Description = "È il valore del Codice Fiscale della Nazione. I valori sono 0=Numerico 1=Alfanumerico")]
        public int? Ntn_TipoCF { get; set; }

        [SwaggerSchema(Description = "È la lunghezza del campo del Codice Fiscale della Nazione")]
        public int? Ntn_LunghezzaCF { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "È la descrizione che deve essere inserita nel campo relativo della form per la Nazione")]
        public string? Ntn_DescStatoRegione { get; set; }

        [SwaggerSchema(Description = "Se il campo è a True gli Stati/Regioni della Nazione sono presenti nella relativa tabella. Quando nelle Form è richiesto questo valore il campo è un campo Combo Box a Scelta Singola con Ricerca invece che un campo Testo")]
        public bool? Ntn_StatoRegione { get; set; }

        [SwaggerSchema(Description = "È la lunghezza del campo Sigla Provincia della Nazione")]
        public int? Ntn_LungSiglaProv { get; set; }

        [SwaggerSchema(Description = "Se il campo è a True la Nazione ha le Province")]
        public bool? Ntn_ProvSiNo { get; set; }

        [SwaggerSchema(Description = "Se il campo è a True le provincie della Nazione sono presenti nella relativa tabella. Quando nelle Form è richiesto questo valore il campo è un campo Combo Box a Scelta Singola con Ricerca invece che un campo Testo")]
        public bool? Ntn_Province { get; set; }

        [SwaggerSchema(Description = "Se il campo è a True le Località (Città) della Nazione sono presenti nella relativa tabella. Quando nelle Form è richiesto questo valore il campo è un campo Combo Box a Scelta Singola con Ricerca invece che un campo Testo")]
        public bool? Ntn_Localita { get; set; }

        [SwaggerSchema(Description = "Se il campo è a True gli indirizzi della Nazione sono presenti nella relativa tabella. Quando nelle Form è richiesto questo valore il campo è un campo Combo Box a Scelta Singola con Ricerca invece che un campo Testo")]
        public bool? Ntn_Indirizzi { get; set; }
    }
}
