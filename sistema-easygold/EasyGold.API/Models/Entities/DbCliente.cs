
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    public class DbCliente
    {
        /// <summary>
        /// ID automatico del cliente.
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Utw_IDClienteAuto { get; set; }

        /// <summary>
        /// Nome della connessione del cliente.
        /// </summary>
        public string Utw_NomeConnessione { get; set; }

        /// <summary>
        /// Stringa di connessione del cliente.
        /// </summary>
        public string Utw_StringaConnessione { get; set; }

        /// <summary>
        /// Data di attivazione del cliente.
        /// </summary>
        public DateTime Utw_DataAttivazione { get; set; }

        /// <summary>
        /// Data di disattivazione del cliente.
        /// </summary>
        public DateTime Utw_DataDisattivazione { get; set; }

        /// <summary>
        /// Numero di negozi attivabili per il cliente.
        /// </summary>
        public int Utw_NegoziAttivabili { get; set; }

        /// <summary>
        /// Numero di negozi virtuali per il cliente.
        /// </summary>
        public int Utw_NegoziVirtuali { get; set; }

        /// <summary>
        /// Numero di utenti attivi per il cliente.
        /// </summary>
        public int Utw_UtentiAttivi { get; set; }

        /// <summary>
        /// Percorso dei report per il cliente.
        /// </summary>
        public string Utw_PercorsoReports { get; set; }

        /// <summary>
        /// Percorso delle immagini per il cliente.
        /// </summary>
        public string Utw_PercorsoImmagini { get; set; }

        /// <summary>
        /// Indica se il cliente è bloccato.
        /// </summary>
        public bool Utw_Blocco { get; set; }
    }
}
