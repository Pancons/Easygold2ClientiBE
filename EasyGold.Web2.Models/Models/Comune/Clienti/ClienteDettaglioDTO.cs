using Swashbuckle.AspNetCore.Annotations;
/*using EasyGold.API.Models.Allegati;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Models.Negozi;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models.Configurazioni;*/
using System.ComponentModel.DataAnnotations;
/*using EasyGold.API.Models.Valute;
using EasyGold.API.Models.StatiCliente;*/
using System.Text.Json.Serialization;
using EasyGold.Web2.Models.Comune.Moduli;

namespace EasyGold.Web2.Models.Comune.Clienti
{

    public class ClienteDettaglioDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del cliente")]
        public int? Utw_IDClienteAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Ragione sociale del cliente")]
        public string Dtc_RagioneSociale { get; set; }

        [SwaggerSchema(Description = "Nome della gioielleria del cliente")]
        [StringLength(100)]
        public string Dtc_Gioielleria { get; set; }

        [SwaggerSchema(Description = "Indirizzo del cliente")]
        [StringLength(100)]
        public string? Dtc_Indirizzo { get; set; }

        [SwaggerSchema(Description = "Città del cliente")]
        [StringLength(100)]
        public string? Dtc_Citta { get; set; }

        [SwaggerSchema(Description = "CAP del cliente")]
        [StringLength(10)]
        public string? Dtc_CAP { get; set; }

        [SwaggerSchema(Description = "Provincia del cliente")]
        [StringLength(100)]
        public string? Dtc_Provincia { get; set; }

        [SwaggerSchema(Description = "Stato o regione del cliente")]
        [StringLength(100)]
        public string? Dtc_StatoRegione { get; set; }

        [SwaggerSchema(Description = "ID Nazione del cliente")]
        public int? Dtc_Nazione { get; set; }

        [SwaggerSchema(Description = "Partita IVA del cliente")]
        [StringLength(30)]
        public string? Dtc_PartitaIVA { get; set; }

        [SwaggerSchema(Description = "Codice fiscale del cliente")]
        [StringLength(30)]
        public string? Dtc_CodiceFiscale { get; set; }

        [SwaggerSchema(Description = "Codice REA del cliente")]
        [StringLength(30)]
        public string? Dtc_REA { get; set; }

        [SwaggerSchema(Description = "Capitale sociale del cliente")]
        public decimal? Dtc_CapitaleSociale { get; set; }

        [SwaggerSchema(Description = "PEC del cliente")]
        public string? Dtc_PEC { get; set; }

        [SwaggerSchema(Description = "Cognome del referente del cliente")]
        public string? Dtc_ReferenteCognome { get; set; }

        [SwaggerSchema(Description = "Nome del referente del cliente")]
        public string? Dtc_ReferenteNome { get; set; }

        [SwaggerSchema(Description = "Telefono del referente del cliente")]
        public string? Dtc_ReferenteTelefono { get; set; }

        [SwaggerSchema(Description = "Cellulare del referente del cliente")]
        public string? Dtc_ReferenteCellulare { get; set; }

        [SwaggerSchema(Description = "Email del referente del cliente")]
        public string? Dtc_ReferenteEmail { get; set; }

        [SwaggerSchema(Description = "Sito web del referente del cliente")]
        public string? Dtc_ReferenteWeb { get; set; }

        [SwaggerSchema(Description = "Ranking del cliente")]
        public int? Dtc_Ranking { get; set; }

        [SwaggerSchema(Description = "Lista dei moduli del cliente")]
        public List<ModuloClienteDTO>? Moduli { get; set; }

        /*[SwaggerSchema(Description = "Configurazione del cliente")]
        public ConfigurazioneDTO Configurazione { get; set; }

        

        [SwaggerSchema(Description = "Lista degli allegati del cliente")]
        public List<AllegatoDTO>? Allegati { get; set; }

        [SwaggerSchema(Description = "Lista dei negozi del cliente")]
        public List<NegozioDTO>? Negozi { get; set; }

        /// <summary>
        /// Creo 2 oggetti Nazione, per gestirne solo la serializzazione in output
        /// </summary>
        [SwaggerSchema(Description = "Dettaglio Nazione del cliente")]
        [JsonIgnore]
        public NazioniDTO? Nazione { get; set; }

        [SwaggerSchema(Description = "Dettaglio Nazione del cliente")]
        [JsonPropertyName("nazione")]
        public NazioniDTO? NazioneOutput => Nazione;*/

    }

}


