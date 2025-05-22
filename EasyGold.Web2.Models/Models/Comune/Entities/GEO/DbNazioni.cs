using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    [Table("tbco_ISONazioni")]
    public class DbNazioni : BaseDbEntity
    {
        [Key]  // <- Definisce la chiave primaria
        public int Ntn_ISO1 { get; set; }

        /// <summary>
        /// Nome della nazione
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Ntn_Descrizione { get; set; }

        /// <summary>
        /// È la sigla ISO 3166-1 Alfa-2 della Nazione.
        /// </summary>
        [StringLength(2)]
        public string? Ntn_ISO1A2 { get; set; }

        /// <summary>
        /// È la sigla ISO 3166-1 Alfa-3 della Nazione
        /// </summary>
        [StringLength(3)]
        public string? Ntn_ISO1A3 { get; set; }

        /// <summary>
        /// È il prefisso telefonico internazionale della Nazione
        /// </summary>
        [StringLength(10)]
        public string? Ntn_PrefTelef { get; set; }
        /// <summary>
        /// È l’ID della tabella “Continenti”
        /// </summary>
        public int? Ntn_Continente { get; set; }
        /// <summary>
        /// È l’ID della tabella “Continenti”..
        /// </summary>
        public int? Ntn_ContinenteLegale { get; set; }
        /// <summary>
        /// È il numero ISO 3166 1 della Nazione a cui appartiene il territorio.
        /// </summary>
        public int? Ntn_Appartiene { get; set; }

        /// <summary>
        /// È la Capitale De Iure della Nazione.
        /// </summary>
        [StringLength(100)]
        public string? Ntn_Capitale { get; set; }

        /// <summary>
        /// È la Capitale De Facto della Nazione
        /// </summary>
        [StringLength(100)]
        public string? Ntn_CapitaleDeFacto { get; set; }

        /// <summary>
        /// È la Capitale Amministrativa della Nazione.
        /// </summary>
        [StringLength(100)]
        public string? Ntn_CapitaleAmm { get; set; }

        /// <summary>
        /// È la Capitale nella lingua originale della Nazione.
        /// </summary>
        [StringLength(100)]
        public string? Ntn_CapitaleIdioma { get; set; }
        /// <summary>
        /// È il codice della valuta presente nella tabella Valute.
        /// </summary>
        public int? Ntn_IDValuta { get; set; }
        /// <summary>
        /// È la lunghezza del CAP della Nazione.
        /// </summary>
        public int? Ntn_LunghezzaCAP { get; set; }

        /// <summary>
        /// È il nome della Partita IVA nella Nazione.
        /// </summary>
        [StringLength(50)]
        public string? Ntn_NomePI { get; set; }

        /// <summary>
        /// È il valore del Tipo di Partita IVA della Nazione. I valori sono 0=Numerica 1=Alfanumerica.
        /// </summary>
        public int? Ntn_TipoPI { get; set; }

        /// <summary>
        /// È la lunghezza del campo della Partita IVA della Nazione.
        /// </summary>
        public int? Ntn_LunghezzaPI { get; set; }

        /// <summary>
        /// È il nome del C.F. nella Nazione.
        /// </summary>
        [StringLength(50)]
        public string? Ntn_NomeCF { get; set; }

        /// <summary>
        /// È il valore del Codice Fiscale della Nazione. I valori sono 0=Numerico 1=Alfanumerico.
        /// </summary>
        public int? Ntn_TipoCF { get; set; }

        /// <summary>
        /// È la lunghezza del campo del Codice Fiscale della Nazione.
        /// </summary>
        public int? Ntn_LunghezzaCF { get; set; }

        /// <summary>
        /// È la descrizione che deve essere inserita nel campo relativo della form per la Nazione.
        /// </summary>
        [StringLength(100)]
        public string? Ntn_DescStatoRegione { get; set; }

        /// <summary>
        /// Se il campo è a True gli Stati/Regioni della Nazione sono presenti nella relativa tabella.
        /// </summary>
        public bool? Ntn_StatoRegione { get; set; }

        /// <summary>
        /// È la lunghezza del campo Sigla Provincia della Nazione.
        /// </summary>
        public int? Ntn_LungSiglaProv { get; set; }

        /// <summary>
        /// Se il campo è a True la Nazione ha le Province.
        /// </summary>
        public bool? Ntn_ProvSiNo { get; set; }

        /// <summary>
        /// Se il campo è a True le provincie della Nazione sono presenti nella relativa tabella
        /// </summary>
        public bool? Ntn_Province { get; set; }

        /// <summary>
        /// Se il campo è a True le Località (Città) della Nazione sono presenti nella relativa tabella.
        /// </summary>
        public bool? Ntn_Localita { get; set; }

        /// <summary>
        /// Se il campo è a True gli indirizzi della Nazione sono presenti nella relativa tabella.
        /// </summary>
        public bool? Ntn_Indirizzi { get; set; }
    }
}