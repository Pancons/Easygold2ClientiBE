using EasyGold.API.Models.StatiCliente;
using EasyGold.API.Models.Valute;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EasyGold.API.Models.Configurazioni
{
    public class ConfigurazioneDTO
    {
        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Numero massimo di negozi attivabili")]
        public int Utw_NegoziAttivabili { get; set; }

        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Numero massimo di negozi virtuali attivabili")]
        public int Utw_NegoziVirtuali { get; set; }

        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Numero massimo di utenti attivi")]
        public int Utw_UtentiAttivi { get; set; }

        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Numero massimo di postazioni")]
        public int Utw_Postazioni { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di attivazione della configurazione")]
        public DateTime Utw_DataAttivazione { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di disattivazione della configurazione")]
        public DateTime? Utw_DataDisattivazione { get; set; }

        [SwaggerSchema(Description = "Stato del cliente")]
        public int? Utw_IdStatoCliente { get; set; }

        [SwaggerSchema(Description = "Numero contratto")]
        public string? Utw_NumeroContratto { get; set; }
        
        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Valuta")]
        public int? Utw_IDValuta { get; set; }

        /// <summary>
        /// Creo 2 oggetti Valuta, per gestirne solo la serializzazione in output
        /// </summary>
        [SwaggerSchema(Description = "Dettaglio Valuta del cliente")]
        [JsonIgnore]
        public ValuteDTO? Valuta { get; set; }

        [SwaggerSchema(Description = "Dettaglio Valuta del cliente")]
        [JsonPropertyName("valuta")]
        public ValuteDTO? ValutaOutput => Valuta;

        /// <summary>
        /// Creo 2 oggetti StatoCliente, per gestirne solo la serializzazione in output
        /// </summary>
        [SwaggerSchema(Description = "Dettaglio Stato del cliente")]
        [JsonIgnore]
        public StatoClienteDTO? StatoCliente { get; set; }

        [SwaggerSchema(Description = "Dettaglio Stato del cliente")]
        [JsonPropertyName("statoCliente")]
        public StatoClienteDTO? StatoClienteOutput => StatoCliente;
    }
}
